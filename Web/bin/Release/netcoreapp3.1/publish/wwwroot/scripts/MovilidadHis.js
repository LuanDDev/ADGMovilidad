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
            dsh.GetMovilidades();
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

        GetMovilidades() {
            $.ajax({
                cache: false,
                url: url_GetMovilidadesHis,
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
                        { title: 'Fecha', width: '50px' },
                        { title: 'Trabajador', width: '120px' },
                        { title: 'DNI', width: '40px' },
                        { title: 'Origen', width: '100px' },
                        { title: 'Destino', width: '100px' },
                        { title: 'Motivo', width: '200px' },
                        { title: 'Transporte', width: '50px' },
                        { title: 'Institución', width: '80px' },
                        { title: 'Hora Salida', width: '50px' },
                        { title: 'Hora Retorno', width: '50px' },
                        { title: 'Monto', width: '80px' },
                    ];

                    var dataSet = [];
                    for (var i = 0; i < ls.length; i++) {
                        dataSet.push([
                            ls[i].IdMov,
                            (ls[i].FechaRegistro != null ? moment(ls[i].FechaRegistro).format('DD/MM/YYYY') : ''),
                            ls[i].Trabajador,
                            ls[i].Dni,
                            ls[i].Origen,
                            ls[i].Destino,
                            ls[i].Motivo,
                            ls[i].Transporte,
                            ls[i].InstDestino,
                            (ls[i].HoraSalida != null ? moment(ls[i].HoraSalida).format('HH:mm') : ''),
                            (ls[i].HoraRetorno != null ? moment(ls[i].HoraRetorno).format('HH:mm') : ''),
                            dsh.monedaSoles((Math.round(ls[i].Monto * 100) / 100).toFixed(2))
                        ]);
                    }
                    var htmlTableDetalle = '';
                    htmlTableDetalle += `
                        <table id="tMovilidades" class="table table-bordered table-hover" style="width: 100%">
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

                    var table = $('#tMovilidades').DataTable({
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
