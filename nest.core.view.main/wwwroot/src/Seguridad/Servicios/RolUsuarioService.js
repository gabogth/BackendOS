function RolUsuarioService() {
    this.path = "/security/RolUsuario"
    const client = new httpClientApi();

    this.Merge = async (roleName, usersId) => {
        const respuesta = await client.executePost(`${this.path}/${roleName}`, usersId);
        return respuesta;
    };
}