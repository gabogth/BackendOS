function FormularioController() {
    this.service = new FormularioService();
    this.moduloService = new ModuloService();
    this.dataSource = null;
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
            insert: async (values) => {
                return await this.service.Agregar(values)
            },
            update: async (key, values) => {
                const originalData = $('#tasks').dxTreeList('instance').getNodeByKey(key).data;
                const updatedData = { ...originalData, ...values }
                return await this.service.Modificar(key, updatedData)
            },
            remove: async (key) => {
                return await this.service.Eliminar(key)
            }
        });
        this.dataSourceModulos = new DevExpress.data.CustomStore({
            key: 'id',
            load: async (options) => {
                return await this.moduloService.ObtenerTodos();
            },
            byKey: async (key) => {
                return await this.moduloService.ObtenerPorId(key);
            }
        });
    };

    this.render = async () => {
        this.settingSources();
        this.renderGrid();
    }

    this.renderGrid = () => {
        $('#tasks').dxTreeList({
            dataSource: this.dataSource,
            keyExpr: 'id',
            parentIdExpr: 'parentId',
            columnAutoWidth: true,
            showRowLines: true,
            showBorders: true,
            newRowPosition: 'pageBottom',
            useIcons: true,
            editing: {
                mode: 'row',
                allowUpdating: true,
                allowAdding: true,
                allowDeleting: true,
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
                    dataField: 'moduloId',
                    caption: 'Modulo',
                    width: '230px',
                    lookup: {
                        dataSource: this.dataSourceModulos,
                        valueExpr: 'id',
                        displayExpr: 'nombre'
                    }
                },
                {
                    dataField: 'nombre',
                    caption: 'Nombre',
                    width: '150px',
                },
                {
                    dataField: 'nombreCorto',
                    caption: 'N.Corto',
                    width: '90px'
                },
                {
                    dataField: 'claimType',
                    caption: 'Claim Type',
                    width: '130px'
                },
                {
                    dataField: 'orden',
                    caption: 'Orden',
                    width: '65px'
                },
                {
                    dataField: 'descripcion',
                    caption: 'Descripción',
                    width: '280px'
                },
                {
                    dataField: 'controlador',
                    caption: 'Controlador',
                    width: '100px'
                },
                {
                    dataField: 'action',
                    caption: 'Action',
                    width: '100px'
                },
                {
                    dataField: 'icono',
                    caption: 'Icono',
                    width: '140px'
                },
                {
                    dataField: 'estado',
                    caption: 'Estado',
                    width: '90px'
                },
                {
                    dataField: 'fechaCreacion',
                    caption: 'Fecha Creacion',
                    width: '180px',
                    dataType: 'date',
                    format: CONSTANTES.formatFechaHoraDisplay,
                    allowEditing: false
                },
                {
                    dataField: 'fechaModificacion',
                    caption: 'Fecha Modificacion',
                    width: '180px',
                    dataType: 'date',
                    format: CONSTANTES.formatFechaHoraDisplay,
                    allowEditing: false
                },
            ],
        });
    }
}