function RolService() {
    this.path = "/security/Rol"
    const client = new httpClientApi();

    this.ObtenerTodos = async () => {
        const respuesta = await client.executeGet(this.path);
        return respuesta;
    };

    this.ObtenerPorId = async (id) => {
        const respuesta = await client.executeGet(`${this.path}/${id}`);
        return respuesta;
    };

    this.Agregar = async (registro) => {
        const respuesta = await client.executePost(`${this.path}`, registro);
        return respuesta;
    };

    this.Modificar = async (registro) => {
        const respuesta = await client.executePut(`${this.path}`, registro);
        return respuesta;
    };

    this.Eliminar = async (registro) => {
        const respuesta = await client.executeDelete(`${this.path}`, registro);
        return respuesta;
    };
}