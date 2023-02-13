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
            dsh.GetVouchers();
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

        obtenerValores() {

            var table = $('#tMovilidades').DataTable();
            var count = table.rows({ selected: true }).count();
            var data = table.rows({ selected: true }).data();

            var ids = '';
            console.log(count);
            if (count == 1) {
                ids = data[0][0];
            } else {
                for (var i = 0; i <= count - 1; i++) {
                    if (i == count - 1) {
                        ids += data[i][0];
                    } else {
                        ids += data[i][0] + ',';
                    }
                }
            }

            return ids;
        },

        GetVouchers() {
            $.ajax({
                cache: false,
                url: url_GetVouchers,
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
                        { title: 'Acciones', width: '80px' },
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
                            '<button type="button" class="btn btn-warning btn-sm editar"><i class="fa fa-edit"></i></button> <button type="button" class="btn btn-danger btn-sm print"><i class="fa fa-print"></i></button>'
                        ]);
                    }
                    var htmlTableDetalle = '';
                    htmlTableDetalle += `
                        <table id="tVouchers" class="table table-bordered table-hover" style="width: 100%">
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

                    var table = $('#tVouchers').DataTable({
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

                    $('#tVouchers tbody').on('click', '.editar', function () {
                        //debugger;
                        var data = table.row($(this).parents('tr')).data();
                        //console.log(data[11]);

                    });
                    $('#tVouchers tbody').on('click', '.eliminar', function () {
                        var data = table.row($(this).parents('tr')).data();
                        //console.log(data[0]);
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
