function serverUtil() {
    this.baseUrl = window.utilController;

    this.actionlink = async (body) => {
        const url = `${this.baseUrl}/actionlink`;
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(body)
        });
        if (!response.ok) {
            const result = await response.json();
            console.log(result);
            throw new Error(response);
        } else {
            const result = await response.json();
            return result;
        }
    };
};