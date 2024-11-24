function Index(pathImagenes) {
    this.pathImagenes = pathImagenes;
    this.service = new ModuloService();
    this.util = new serverUtil();
    this.Initialize = async () => {
        await this.renderModules();
    }

    this.renderModules = async () => {
        try {
            const resultado = await this.service.ObtenerTodos();
            const actions = resultado.map(element => `${element.controlador}.${element.action}`);
            const directions = await this.util.actionlink(actions);
            this.renderSuccessfully(resultado, directions);
        } catch (ex) {
            console.error(ex);
        }
        
    }

    this.renderSuccessfully = (modules, directions) => {
        let row = $('<div class="row">');
        modules.forEach(element => {
            $(`<div class="col-4 ${element.estado ? '' : 'text-secondary'}">
                    ${element.estado ? `<a href="${directions[element.controlador + "." + element.action]}" class="text-decoration-none text-reset">` : '<div style="cursor: not-allowed;">'}
                        <div class="card mb-3" style="max-width: 540px;">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img src="${this.pathImagenes}/${element.nombreCorto}.png" class="img-fluid rounded-start" alt="...">
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title">${element.nombre}</h5>
                                        <p class="card-text">${element.descripcion}</p>
                                        <p class="card-text text-end"><small class="text-body-secondary"><i class="fa-solid fa-circle ${element.estado ? 'text-success' : 'text-secondary'}"></i> ${element.estado ? 'Activo' : 'Inactivo'}</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ${element.estado ? '</a>' : '</div>'}
                </div>`).appendTo(row);
        });
        row.appendTo(`#contenido`);
    }
}