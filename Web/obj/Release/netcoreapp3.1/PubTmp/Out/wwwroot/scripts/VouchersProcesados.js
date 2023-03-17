$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {
            if (sessionStorage.IdEmpresa == null || sessionStorage.IdEmpresa == undefined) {
                document.location.href = url_selectCompany;
            }

            $('#fecFin').val(moment().format('YYYY-MM-DD'));
            $('#fecIni').val(moment().add(-120, 'days').format('YYYY-MM-DD'));

            $('#spinner_loading').show();
            dsh.GetVouchersProcesados();
        },

        monedaSoles(value) {
            const formatter = new Intl.NumberFormat('es-PE', { style: 'currency', currency: 'PEN' })
            return formatter.format(value)
        },

        sumarDias(fecha, dias) {
            fecha.setDate(fecha.getDate() + dias);
            return fecha;
        },

        padTo2Digits(num) {
            return num.toString().padStart(2, '0');
        },

        formatDate(date) {
            return [
                date.getFullYear(),
                dsh.padTo2Digits(date.getMonth() + 1),
                dsh.padTo2Digits(date.getDate()),
            ].join('-');
        },

        GetVouchersProcesados() {
            $.ajax({
                cache: false,
                url: url_GetVouchersProcesados,
                type: "POST",
                data: {
                    fecIni: $('#fecIni').val(),
                    fecFin: $('#fecFin').val(),
                    companyId: sessionStorage.IdEmpresa,
                },
                success: function (data) {
                    var ls = JSON.parse(data.value).data;

                    var columns = [];
                    columns = [
                        { title: 'ID', width: '40px' },
                        { title: 'Usuario', width: '120px' },
                        { title: 'Empresa', width: '120px' },
                        { title: 'DNI', width: '50px' },
                        { title: 'Fecha', width: '50px' },
                        { title: 'Monto', width: '70px' },
                        { title: 'Monto no Reparable', width: '100px' },
                        { title: 'Estado', width: '70px' },
                        { title: 'Detalle', width: '80px' },
                    ];

                    var dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([
                            ls[i].IdVoucher,
                            ls[i].Usuario,
                            ls[i].Empresa,
                            ls[i].Dni,
                            (ls[i].Fecha != null ? moment(ls[i].Fecha).format('DD/MM/YYYY') : ''),
                            ls[i].Monto,
                            ls[i].MontoNoReparable,
                            ls[i].Estado,
                            ''
                        ]);
                    }
                    var htmlTableDetalle = '';
                    htmlTableDetalle += `
                        <table id="tVouchersProc" class="table table-bordered table-hover" style="width: 100%">
                            <thead>
                                <tr>`;
                    for (var i = 0; i < columns.length; i++) {
                        htmlTableDetalle += `<th style="width: ` + columns[i].width + `">` + columns[i].title + `</th>`;
                    }
                    htmlTableDetalle += `
                                </tr>
                            </thead>`;
                    htmlTableDetalle += `
                            <tbody>`;
                    for (var i = 0; i < dataSet.length; i++) {
                        htmlTableDetalle += `<tr style="vertical-align: middle;">`;
                        for (var j = 0; j < dataSet[i].length; j++) {
                            htmlTableDetalle += `
                            <td>` + (dataSet[i][j] == null ? '' : dataSet[i][j]) + `</td>
                            `;
                        }
                        htmlTableDetalle += `</tr>`;
                    }
                    htmlTableDetalle += `
                            </tbody>
                        </table>`;


                    $('#div_table').html(htmlTableDetalle);

                    var table = $('#tVouchersProc').DataTable({
                        destroy: true,
                        select: {
                            style: 'multi'
                        },
                        //scrollY: 400,
                        //scrollX: true,
                        //scrollCollapse: true,
                        //fixedColumns: true,
                        //responsive: true,
                        initComplete: function () {
                            $(this.api().table().container()).find('input[type="search"]').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                        },
                        language: {
                            url: "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json",
                            select: {
                                rows: {
                                    _: "Ud. seleccionó %d filas",
                                    0: "Haga click en una fila para seleccionarla",
                                    1: "Solo 1 fila seleccionada"
                                }
                            }
                        }
                    });

                    $('#spinner_loading').hide();
                },
                error: function () {
                    console.log("Error");
                }
            });
        },
    };

    dsh.init();
});
