function multilvl() {
    this.data = [];

    this.setData = (data) => {
        this.data = data;
    };

    this.run = () => {
        let main = $(`#navBarList`);
        let firstRow = this.getByIdParent(null);
        firstRow.forEach((element) => {
            const cantidadHijos = this.getChildsNumber(element.id);
            if (cantidadHijos == 0)
                $(`<li class="nav-item">
                    <a class="nav-link" aria-current="page" href="${element.url}"><i class="fa-solid fa-${element.icono}"></i> ${element.nombre}</a>
                </li>`).appendTo(main);
            else {
                $(`<li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown" data-bs-auto-close="outside"><i class="fa-solid fa-${element.icono}"></i> ${element.nombre}</a>
                        <ul class="dropdown-menu shadow" id="dropdown-${element.id}">
                        </ul>
                    </li>`).appendTo(main);
                this.run2(element.id);
            }
        });
        this.optimizeRender();
    };

    this.run2 = (idParent) => {
        let records = this.getByIdParent(idParent);
        records.forEach((element) => {
            const cantidadHijos = this.getChildsNumber(element.id);
            if (cantidadHijos == 0) {
                $(`<li><a class="dropdown-item" href="${element.url}"><i class="fa-solid fa-${element.icono}"></i> ${element.nombre}</a></li>`).appendTo(`#dropdown-${element.parentId}`);
            } else {
                $(`<li class="dropstart">
                        <a href="#" class="dropdown-item dropdown-toggle" data-bs-toggle="dropdown"><i class="fa-solid fa-${element.icono}"></i> ${element.nombre}</a>
                        <ul class="dropdown-menu shadow" id="dropdown-${element.id}">
                        </ul>
                    </li>`).appendTo(`#dropdown-${element.parentId}`);
                this.run2(element.id);
            }
        });
    }

    this.renderString = (value) => {
        $(`#navBarList`).html(value);
    };

    this.getByIdParent = (idParent) => {
        return this.data.filter((element) => element.parentId == idParent).sort((a, b) => a.orden - b.orden);
    };

    this.getChildsNumber = (id) => {
        return this.getByIdParent(id).length;
    };

    this.optimizeRender = () => {
        var navbarToggler = document.querySelectorAll('.navbar-toggler')[0];
        var html = document.querySelectorAll('html')[0];
        var themeToggle = document.querySelectorAll('*[data-bs-toggle-theme]')[0];
        html.setAttribute('data-bs-theme', 'dark');
        if (themeToggle) {
            themeToggle.addEventListener('click', function (event) {
                event.preventDefault();
                if (html.getAttribute('data-bs-theme') === 'dark') {
                    html.setAttribute('data-bs-theme', 'light');
                } else {
                    html.setAttribute('data-bs-theme', 'dark');
                }
            });
        }
    };
}