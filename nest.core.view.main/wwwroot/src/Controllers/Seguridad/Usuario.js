function UsuarioController() {
    this.service = new UsuarioService();
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
                const user = { user: { ...values }, password: values.password }
                return await this.service.Agregar(user)
            },
            update: async (key, values) => {
                const originalData = await $('#grid').dxDataGrid('instance').getVisibleRows().map(x => x.data).find(x => x.id == key);
                const updatedData = { ...originalData, ...values };
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
                    dataField: 'email',
                    caption: 'Correo',
                    width: '150px',
                    validationRules: [
                        { type: 'required', message: 'El campo correo es obligatorio' },
                        { type: 'email', message: 'Por favor, introduce un correo válido' }
                    ]
                },
                {
                    dataField: 'password',
                    caption: 'Password',
                    width: '150px',
                    editorOptions: {
                        mode: 'password',
                    },
                },
                {
                    dataField: 'phoneNumber',
                    caption: 'Celular',
                    width: '150px',
                }
            ],
            onEditorPreparing: function (e) {
                if (e.row && !e.row.isNewRow)
                    if (e.dataField === 'email' || e.dataField === 'password')
                        e.editorOptions.readOnly = true;
            },
        });
    };
}