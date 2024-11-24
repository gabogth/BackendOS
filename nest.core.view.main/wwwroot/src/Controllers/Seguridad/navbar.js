function NavBar(idModulo) {
    this.service = new FormularioService();
    this.util = new serverUtil();
    this.nav = new multilvl();
    this.idModulo = idModulo;
    this.Initialize = async () => {
        await this.renderNav();
    }

    this.renderNav = async () => {
        try {
            const resultado = await this.service.ObtenerPorModuloId(this.idModulo);
            const actions = resultado.reduce((prev, curr) => {
                var exists = prev.indexOf(`${curr.controlador}.${curr.action}`);
                if (exists == -1) {
                    var hijo = resultado.find(obj => obj.parentId == curr.id);
                    if (!hijo)
                        prev.push(`${curr.controlador}.${curr.action}`);
                }
                return prev;
            }, []);
            const directions = await this.util.actionlink(actions);
            resultado.map((element) => {
                element['url'] = directions[`${element.controlador}.${element.action}`];
                return element;
            });
            this.renderSuccessfully(resultado);
        } catch (ex) {
            console.error(ex);
            this.renderError(ex);
        }
    }

    this.renderSuccessfully = (modules) => {
        this.nav.setData(modules);
        this.nav.run();
    }

    this.renderError = (data) => {
        this.nav.renderString(data);
    }
}