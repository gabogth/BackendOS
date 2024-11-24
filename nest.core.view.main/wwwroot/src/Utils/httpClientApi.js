function httpClientApi() {
    this.baseUrl = window.api;

    this.executePost = async (path, body) => {
        const url = new URL(path, this.baseUrl).toString();
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${window.token}`
            },
            body: JSON.stringify(body)
        });
        if (!response.ok) {
            const result = await response.json();
            if (result.server)
                throw result.message;
            else
                throw response.status;
        } else {
            const result = await response.json();
            return result;
        }
    };

    this.executeGet = async (path) => {
        const url = new URL(path, this.baseUrl).toString();
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${window.token}`
            }
        });
        if (!response.ok) {
            const result = await response.json();
            if (result.server)
                throw result.message;
            else
                throw response.status;
        } else {
            const result = await response.json();
            return result;
        }
    }

    this.executePut = async (path, body) => {
        const url = new URL(path, this.baseUrl).toString();
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${window.token}`
            },
            body: JSON.stringify(body)
        });
        if (!response.ok) {
            const result = await response.json();
            if (result.server)
                throw result.message;
            else
                throw response.status;
        } else {
            const result = await response.json();
            return result;
        }
    };

    this.executeDelete = async (path, body) => {
        const url = new URL(path, this.baseUrl).toString();
        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${window.token}`
            },
            body: JSON.stringify(body)
        });
        if (!response.ok) {
            const result = await response.json();
            if (result.server)
                throw result.message;
            else
                throw response.status;
        } else {
            const result = await response.json();
            return result;
        }
    };
};