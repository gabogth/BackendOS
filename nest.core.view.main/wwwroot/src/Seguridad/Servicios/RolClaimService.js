function RolClaimService() {
    this.path = "/security/RolClaim"
    const client = new httpClientApi();

    this.Merge = async (roleId, registro) => {
        const respuesta = await client.executePost(`${this.path}/${roleId}`, registro);
        return respuesta;
    };
}