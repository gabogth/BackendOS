function RolFormularioController() {
    this.service = new RolService();
    this.formularioService = new FormularioService();
    this.moduloService = new ModuloService();
    this.rolClaimService = new RolClaimService();
    this.dataSource = null;
    this.dataSourceFormularios = null;
    this.dataSourceModulos = null;
    this.Initialize = async () => {
        this.render();
    }

    this.settingSources = () => {
        this.dataSource = new DevExpress.data.CustomStore({
            key: 'id',
            load: async (options) => {
                return await this.service.ObtenerTodos();
            },
            byKey: async (id) => {
                return await this.service.ObtenerPorId(id);
            }
        });
        this.dataSourceFormularios = new DevExpress.data.CustomStore({
            key: 'id',
            load: async (options) => {
                return await this.formularioService.ObtenerTodos();
            }
        });
        this.dataSourceModulos = new DevExpress.data.CustomStore({
            key: 'id',
            load: async (options) => {
                return await this.moduloService.ObtenerTodos();
            }
        });
    };

    this.render = async () => {
        this.settingSources();
        this.renderGrid();
        this.renderPermisos();
    }

    this.renderGrid = () => {
        $('#grid').dxDataGrid({
            dataSource: this.dataSource,
            keyExpr: 'id',
            columnAutoWidth: true,
            showRowLines: true,
            showBorders: true,
            newRowPosition: 'pageBottom',
            useIcons: true,
            selection: {
                mode: 'single'
            },
            searchPanel: {
                visible: true,
                width: 250,
            },
            headerFilter: {
                visible: true,
            },
            columns: [
                {
                    dataField: 'id',
                    caption: 'Id',
                    width: '250px',
                    allowEditing: false
                },
                {
                    dataField: 'name',
                    caption: 'Nombre',
                    width: '150px',
                }
            ],
            onSelectionChanged: async (selectedItems) => {
                const data = selectedItems.selectedRowsData[0];
                if (data) {
                    await this.renderSelection(data);
                }
            },
        });
    };

    this.renderPermisos = () => {
        $('#permisos').dxTreeList({
            dataSource: this.dataSourceFormularios,
            keyExpr: 'id',
            parentIdExpr: 'parentId',
            columnAutoWidth: true,
            showRowLines: true,
            showBorders: true,
            selection: {
                mode: "multiple",
                recursive: true,
                allowSelectAll: true
            },
            searchPanel: {
                visible: true,
                width: 250,
            },
            headerFilter: {
                visible: true,
            },
            columns: [
                {
                    dataField: 'nombre',
                    caption: 'Nombre'
                },
                {
                    dataField: 'moduloId',
                    caption: 'Modulo',
                    lookup: {
                        dataSource: this.dataSourceModulos,
                        valueExpr: 'id',
                        displayExpr: 'nombre'
                    }
                },
            ],
            toolbar: {
                items: [
                    {
                        widget: 'dxButton',
                        options: {
                            text: 'Guardar',
                            icon: 'save',
                            onClick: async () => {
                                const data = $('#grid').dxDataGrid('instance').getSelectedRowsData();
                                const dataClaims = $('#permisos').dxTreeList('instance').getSelectedRowsData();
                                if (data.length > 0) {
                                    const roleId = data[0].id;
                                    const claims = this.getIds(dataClaims);
                                    try {
                                        $('#grid').dxDataGrid('instance').beginCustomLoading("Guardando los cambios...");
                                        $('#permisos').dxTreeList('instance').beginCustomLoading("Guardando los cambios...");
                                        await this.rolClaimService.Merge(roleId, claims);
                                        DevExpress.ui.notify({
                                            type: "success",
                                            position: 'center',
                                            message: "Correcto!",
                                            closeOnClick: true
                                        });
                                        $('#grid').dxDataGrid('instance').endCustomLoading();
                                        $('#permisos').dxTreeList('instance').endCustomLoading();

                                    } catch (ex) {
                                        DevExpress.ui.notify({
                                            type: "error",
                                            position: 'center',
                                            message: ex,
                                            closeOnClick: true
                                        });
                                    }
                                } else {
                                    DevExpress.ui.notify({
                                        type: "error",
                                        position: 'center',
                                        message: "Error: Debes seleccionar almenos un rol",
                                        closeOnClick: true
                                    });
                                }
                            }
                        },
                        location: 'after'
                    }
                ]
            }
        });
    }

    this.renderSelection = async (selection) => {
        const formularios = await this.formularioService.ObtenerPorRolId(selection.id);
        const indexes = formularios.map(element => element.id);
        $('#permisos').dxTreeList('instance').selectRows(indexes, false);
    };

    this.getIds = (data) => {
        let ids = [];
        if (!data || data.length == 0) return [];
        const recursive = (data) => {
            data.forEach((element) => {
                if (element.children && element.children.length > 0)
                    recursive(element.children);
                else
                    ids.push({ type: element.claimType, value: "true" });
            });
        };
        recursive(data);
        return ids;
    };
}