function RolController() {
    this.service = new RolService();
    this.dataSource = null;
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
                const originalData = await $('#grid').dxDataGrid('instance').getVisibleRows().map(x => x.data).find(x => x.id == key);
                console.log('originalData', originalData);
                const updatedData = { ...originalData, ...values }
                return await this.service.Modificar(updatedData);
            },
            remove: async (key) => {
                const originalData = await $('#grid').dxDataGrid('instance').getVisibleRows().map(x => x.data).find(x => x.id == key);
                return await this.service.Eliminar(originalData);
            },
            byKey: async (id) => {
                return await this.service.ObtenerPorId(id);
            }
        });
    };

    this.render = async () => {
        this.settingSources();
        this.renderGrid();
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
            ]
        });
    };
}