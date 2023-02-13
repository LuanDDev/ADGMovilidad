let sum = 0;
$(document).ready(function () {
    var dsh = {
        init: function () {
            dsh.evento();
        },

        evento() {

            if (sessionStorage.IdEmpresa == null || sessionStorage.IdEmpresa == undefined) {
                document.location.href = url_selectCompany;
            }

            $('#lblSuma').text(dsh.monedaSoles(sum));
            $('#lblSuma').addClass('d-inline-flex mb-3 px-2 py-1 fw-semibold text-success-emphasis bg-success-subtle border border-success-subtle rounded-2'),

            $('#fecFin').val(moment().format('YYYY-MM-DD'));
            $('#fecIni').val(moment().add(-120, 'days').format('YYYY-MM-DD'));

            $('#spinner_loading').show();
            dsh.GetMovilidades();

            $(document).on('click', '#btnNuevo', function () {
                $('#txtFechaRegistro').val(moment().format('YYYY-MM-DD'));
                $('#mRegistro').modal('show');
            });

            $(document).on('click', '#btnGuardarMovilidad', function () {
                $('#spinner_loading').show();
                dsh.InsertMovilidad();
            });
            $(document).on('click', '#btnGenerarVoucher', function () {
                $('#spinner_loading').show();
                dsh.CrearVoucher();
            });

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

        GetMovilidades() {
            $.ajax({
                cache: false,
                url: url_GetMovilidades,
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
                        { title: 'Acciones', width: '80px' },
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
                            dsh.monedaSoles((Math.round(ls[i].Monto * 100) / 100).toFixed(2)),
                            '<button type="button" class="btn btn-warning btn-sm editar"><i class="fa fa-edit"></i></button> <button type="button" class="btn btn-danger btn-sm eliminar"><i class="fa fa-trash"></i></button>'
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

                    $('#tMovilidades tbody').on('click', function () {
                        //debugger;
                        setTimeout(() => {
                            var rows = table.rows({ selected: true }).data();
                            //var total = table.column(11).data();

                            //var sum = table.column(11, { selected: true }).data()
                            //console.log(rows[0]);
                            //console.log(total);
                            console.log(rows);
                            sum = 0;
                            for (var i = 0; i < rows.length; i++) {
                                sum += (parseInt(rows[i][11].replace('S/&nbsp;', '')) == null ? 0 : parseInt(rows[i][11].replace('S/&nbsp;', '')));
                            }

                            if (sum > 41) {
                                //text-white bg-success border border-success
                                $('#lblSuma').removeClass('text-white bg-green border border-green');
                                $('#lblSuma').addClass('text-white bg-danger border border-danger');
                            } else if (sum > 0 && sum <= 41){
                                $('#lblSuma').removeClass('text-white bg-danger border border-danger');
                                $('#lblSuma').addClass('text-white bg-green border border-green');
                            } else {
                                $('#lblSuma').removeClass('text-white bg-danger border border-danger');
                                $('#lblSuma').removeClass('text-white bg-green border border-green');
                            }

                            $('#lblSuma').text(dsh.monedaSoles(sum));
                        }, "100")

                        
                        
                    });

                    $('#tMovilidades tbody').on('click', '.editar', function () {
                        //debugger;
                        var data = table.row($(this).parents('tr')).data();
                        //console.log(data[11]);
                        
                    });
                    $('#tMovilidades tbody').on('click', '.eliminar', function () {
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

        InsertMovilidad() {
            $.ajax({
                cache: false,
                url: url_InsertMovilidad,
                type: "POST",
                data: {
                    idMov: $('#txtIdMov').val(),
                    CodEmpresa: sessionStorage.IdEmpresa,
                    CCosto: $('#txtCentroCosto').val(),
                    Origen: $('#txtDistritoOrigen').val(),
                    Destino: $('#txtDistritoDestino').val(),
                    Motivo: $('#txtMotivo').val(),
                    Transporte: $('#sTransporte').val(),
                    InstDestino: $('#txtInsDestino').val(),
                    HoraSalida: $('#txtHoraSalida').val(),
                    HoraRetorno: $('#txtHoraRetorno').val(),
                    Monto: $('#txtMonto').val(),
                    FechaRegistro: $('#txtFechaRegistro').val()
                },
                success: function (data) {
                    var ls = JSON.parse(data.value).data;

                    if (data.status) {
                        Swal.fire({
                            icon: 'Success', /*'success','error','warning','info','question'*/
                            title: 'Éxito',
                            text: 'Se grabó correctamente'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                $('#mRegistro').modal('hide');
                                dsh.GetMovilidades();
                            }
                        })
                    }
                    
                },
                error: function () {
                    console.log("Error");
                }
            });
        },

        CrearVoucher() {

            if (sum > 41) {
                Swal.fire({
                    icon: 'error', /*'success','error','warning','info','question'*/
                    title: 'Cuidado',
                    text: 'No puedes exceder de S/.41.00'
                }).then((result) => {
                    if (result.isConfirmed) {
                        
                    }
                })
            } else if (sum == 0) {
                Swal.fire({
                    icon: 'error', /*'success','error','warning','info','question'*/
                    title: 'Cuidado',
                    text: 'Debes seleccionar un registro'
                }).then((result) => {
                    if (result.isConfirmed) {

                    }
                })
            } else {
                var ids = dsh.obtenerValores();

                $.ajax({
                    cache: false,
                    url: url_CrearVoucher,
                    type: "POST",
                    data: {
                        companyId: sessionStorage.IdEmpresa,
                        ids: ids
                    },
                    success: function (data) {
                        var ls = JSON.parse(data.value).data;

                        dsh.ImprimirVoucher(ls[0].IdVoucher);

                    },
                    error: function () {
                        console.log("Error");
                    }
                });
            }
        },

        ImprimirVoucher(id) {
            location.href = url_ImprimirVoucher + '/' + id;
            sum = 0;
            $('#lblSuma').text(dsh.monedaSoles(sum));
            dsh.GetMovilidades();
            $('#spinner_loading').hide();
        },
    };


    dsh.init();
});
