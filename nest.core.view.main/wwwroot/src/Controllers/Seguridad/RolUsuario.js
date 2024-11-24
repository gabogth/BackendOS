function RolUsuarioController() {
    this.service = new RolService();
    this.usuarioService = new UsuarioService();
    this.rolUsuarioService = new RolUsuarioService();
    this.dataSource = null;
    this.dataSourceUsuarios = null;
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
        this.dataSourceUsuarios = new DevExpress.data.CustomStore({
            key: 'id',
            load: async (options) => {
                return await this.usuarioService.ObtenerTodos();
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
                    width: '250px'
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
        $('#usuarios').dxDataGrid({
            dataSource: this.dataSourceUsuarios,
            keyExpr: 'id',
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
                    dataField: 'email',
                    caption: 'Correo'
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
                                const users = $('#usuarios').dxDataGrid('instance').getSelectedRowsData();
                                if (data.length > 0) {
                                    const roleName = data[0].name;
                                    const usuarios = users.map(x => x.id);
                                    try {
                                        $('#grid').dxDataGrid('instance').beginCustomLoading("Guardando los cambios...");
                                        $('#usuarios').dxDataGrid('instance').beginCustomLoading("Guardando los cambios...");
                                        await this.rolUsuarioService.Merge(roleName, usuarios);
                                        DevExpress.ui.notify({
                                            type: "success",
                                            position: 'center',
                                            message: "Correcto!",
                                            closeOnClick: true
                                        });
                                        $('#grid').dxDataGrid('instance').endCustomLoading();
                                        $('#usuarios').dxDataGrid('instance').endCustomLoading();

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
        const usuarios = await this.usuarioService.ObtenerPorRol(selection.name);
        const indexes = usuarios.map(element => element.id);
        $('#usuarios').dxDataGrid('instance').selectRows(indexes, false);
    };
}