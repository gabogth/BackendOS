function ModuloService() {
    this.path = "/security/Modulo"
    const client = new httpClientApi();

    this.ObtenerTodos = async () => {
        const respuesta = await client.executeGet(this.path);
        return respuesta;
    };

    this.ObtenerPorId = async (id) => {
        const respuesta = await client.executeGet(`${this.path}/${id}`);
        return respuesta;
    };

    this.ObtenerPorUnaPropiedad = async (filter) => {
        const respuesta = await client.executePost(`${this.path}/filter`, filter);
        return respuesta;
    };

    this.Agregar = async (registro) => {
        const respuesta = await client.executePost(`${this.path}`, registro);
        return respuesta;
    };

    this.Modificar = async (id, registro) => {
        const respuesta = await client.executePut(`${this.path}/${id}`, registro);
        return respuesta;
    };

    this.Eliminar = async (id, registro) => {
        const respuesta = await client.executeDelete(`${this.path}/${id}`);
        return respuesta;
    };
}