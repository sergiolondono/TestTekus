var urlServiceView = '/api/ServicesCountries';

var spanishLanguage = {
    "sProcessing": "Procesando...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "No se encontraron resultados",
    "sEmptyTable": "Ningún dato disponible en esta tabla",
    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix": "",
    "sSearch": "Buscar:",
    "sUrl": "",
    "sInfoThousands": ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst": "Primero",
        "sLast": "Último",
        "sNext": "Siguiente",
        "sPrevious": "Anterior"
    },
    "oAria": {
        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    }
};

AllCountriesServices();

function AllCountriesServices() {
    $.ajax({
        url: urlServiceView,
        type: 'GET',
        data: JSON.stringify(),
        crossDomain: true,
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        success: function (data) {
            var table = '<table id="countriesServicesTable" class="table table-bordered table-hover table-responsive">';
            table += ' <thead class="btn-primary"><tr><th class="hide">Id Cliente</th><th>Cliente</th>' +
                '<th>Servicio</th><th>País</th></tr></thead>';

            $.each(data, function (key, item) {
                table += ('<tr>');
                table += ('<td class="hide">' + data[key].Id + '</td>');
                table += ('<td>' + data[key].Servicios.Clientes.Nombre + '</td>');
                table += ('<td>' + data[key].Servicios.Nombre + '</td>');
                table += ('<td>' + data[key].Paises.Nombre + '</td>');
                table += ('</tr>');
            });

            table += '</table>';
            $("#tableContainer").html(table);
            var tableFilled = $("#countriesServicesTable").DataTable({
                pageLength: 5,
                lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
                language: spanishLanguage,
                select: true
            });

        },
        error: function () {
            console.log('Countries Services not loaded');
        }
    });
}

function loadServices() {
    $("#servicios").empty();
    $.ajax({
        type: 'GET',
        url: '/api/Services' + '?idClient=' + $('#cliente').val(),
        data: JSON.stringify(),
        crossDomain: true,
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        success: function (data) {
                $("#servicios").addClass("show");
                $.each(data, function (key, item) {
                    $("#servicios").append('<option value="' + data[key].Id + '">' +
                        data[key].Nombre + '</option>');
                });
        },
        error: function (ex) {
            $("#servicios").addClass("hide");
            alert('No se pudo obtener los servicios relacionados con el cliente.' + ex);
        }
    });
}

function saveCountryService() {
    if (($('#cliente').val() != null && $('#cliente').val() != "")
        && ($('#servicios').val() != null && $('#servicios').val() != "")
        && ($('#paises').val() != null && $('#paises').val() != "")) {
        $.post(urlServiceView,
            {
                IdPais: $('#paises').val(),
                IdServicio: $('#servicios').val()
            },
            function (data, status) {
                AllCountriesServices();
                alert("Servicio asociado al país correctamente");
            })
            .fail(function (xhr, status, error) {
                if (xhr.status == 409) {
                    alert("La configuración que desea guardar ya existe en la base de datos");
                }
                else if (xhr.status == 500)
                    alert('Error en la transacción');
            
            });
    }
    else
        alert("Debe diligenciar todos los campos");
}

function updateCountryService() {
    if (($('#cliente').val() != null && $('#cliente').val() != "")
        && ($('#servicios').val() != null && $('#servicios').val() != "")
        && ($('#paises').val() != null && $('#paises').val() != "")) {

        var countryService = new Object();
        countryService.IdPais = $('#paises').val();
        countryService.IdServicio = $('#servicios').val();

        $.ajax({
            type: 'PUT',
            url: urlServiceView + '?id=' + $('#txtIdToUpdate').val(),
            data: countryService,
            success: function (data, textStatus, xhr) {
                $('#countriesServicesTable').empty();
                AllCountriesServices();
                alert("Configuración modificada correctamente");
            },
            error: function (xhr, textStatus, errorThrown) {
                if (xhr.status == 400) {
                    alert("El Id ingresado no se encuentra en el sistema");
                }
                else if (xhr.status == 500)
                    alert('Error en la transacción');
            }
        });
    }
    else
        alert("Debe diligenciar todos los campos");
}