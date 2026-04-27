import { firstValueFrom } from "rxjs";
import Swal, { SweetAlertOptions } from "sweetalert2";

export class NestUtils {
    public static formatValidationErrors(error: any): string {
        if (!error) {
            return 'Ha ocurrido un error desconocido.';
        }
        if(error.error && error.error.errors) {
            const agrupados = error.error.errors.reduce((acc: any, current: any) => {
                if (!acc[current.field]) {
                    acc[current.field] = [];
                }
                acc[current.field].push(current.message);
                return acc;
            }, {});
            console.log('Agrupados:', agrupados);
            let errorMessages = '';
            Object.keys(agrupados).forEach(campo => {
                errorMessages += `${campo}: \n\r`;
                errorMessages += agrupados[campo].map((msg: string) => `\t\t\t > ${msg}`).join('\n\r');
            });
            return errorMessages;
        }
        if(error.error && error.error.detail) {
            return error.error.detail;
        }

        if(error && error.message) {
            return `${error.message}`;
        }
        return 'Ha ocurrido un error desconocido.';
    }

    public static async showConfirmationDialog(options: any) {
        options.confirmTitle = options?.confirmTitle ?? 'Correcto';
        options.confirmText = options?.confirmText ?? 'La acción se realizó con éxito';
        options.confirmIcon = options?.confirmIcon ?? 'success';
        options.funtionToExecute = options?.funtionToExecute ?? (() => {});

        return new Promise<void>(async (resolve, reject) => {
            const result = await Swal.fire({
                title: '¿Estás seguro?',
                text: 'No podrás revertir esta acción',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí',
                cancelButtonText: 'Cancelar',
                showLoaderOnConfirm: true,
                preConfirm: async () => {
                    let resultCall = null;
                    try {
                        if(options.funtionToExecute) resultCall = await firstValueFrom(options.funtionToExecute());
                    } catch (error) {
                        const errorMessage = this.formatValidationErrors(error);
                        Swal.showValidationMessage(errorMessage);
                    }
                    return resultCall;
                },
                allowOutsideClick: () => !Swal.isLoading(),
                customClass: {
                    container: 'swal-on-top',
                },
                ...options
            });
            if (result.isConfirmed) {
                let textResult = '';
                if(typeof options.confirmText === 'string') {
                    textResult = options.confirmText;
                } else if(options.confirmText != undefined) {
                    textResult = await options.confirmText(result.value);
                }
                await Swal.fire({
                    title: options.confirmTitle, 
                    text: textResult, 
                    icon: options.confirmIcon,
                    customClass: {
                        container: 'swal-on-top',
                    },
                });
                resolve(result.value);
            } else {
                reject('Acción cancelada por el usuario');
            }
        });
    }
}