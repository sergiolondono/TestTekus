var urlServiceView = '/api/Services';

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


$(document).ready(function () {
    $("#serviceToModify").change(function () {
            $.ajax({
                type: 'GET',
                url: urlServiceView + '?id=' + $('#serviceToModify').val(),
                data: JSON.stringify(),
                crossDomain: true,
                headers: { "Accept": "application/json", "Content-Type": "application/json" },
                success: function (service) {
                    $('#txtNombreUpdate').val(service.Nombre);
                    $('#txtValorHoraUpdate').val(service.ValorHora);
                    $('#clientToModify').val(service.IdCliente);
                },
                error: function (ex) {
                    alert('No se pudo obtener los servicios relacionados con el cliente.' + ex);
                }
            });

        return false;
    });
});

AllServices();

function AllServices() {
    $.ajax({
        url: urlServiceView,
        type: 'GET',
        data: JSON.stringify(),
        crossDomain: true,
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        success: function (data) {
            var table = '<table id="servicesTable" class="table table-bordered table-hover table-responsive">';
            table += ' <thead class="btn-primary"><tr><th class="hide">Id Cliente</th><th>Nombre</th><th>Valor Hora</th><th>Cliente</th></tr></thead>';

            $.each(data, function (key, item) {
                table += ('<tr>');
                table += ('<td class="hide">' + data[key].Id + '</td>');
                table += ('<td>' + data[key].Nombre + '</td>');
                table += ('<td>' + data[key].ValorHora + '</td>');
                table += ('<td>' + data[key].Clientes.Nombre + '</td>');
                table += ('</tr>');
            });

            table += '</table>';
            $("#tableContainer").html(table);
            var tableFilled = $("#servicesTable").DataTable({
                pageLength: 5,
                lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
                language: spanishLanguage,
                select: true
            });

        },
        error: function () {
            console.log('Services not loaded');
        }
    });
}

function saveService() {
    if (($('#txtNombre').val() != null && $('#txtNombre').val() != "")
        && ($('#txtValorHora').val() != null && $('#txtValorHora').val() != "")
        && ($('#cliente').val() != null && $('#cliente').val() != "")) {
        $.post(urlServiceView,
            {
                Nombre: $('#txtNombre').val(),
                ValorHora: $('#txtValorHora').val(),
                IdCliente: $('#cliente').val()
            },
            function (data, status) {
                cleanSaveFields();
                AllServices();
                alert("Servicio creado correctamente");
            });
    }
    else
        alert("Debe diligenciar todos los campos");
}

function cleanSaveFields() {
    $('#txtNombre').val("");
    $('#txtValorHora').val("");
}

function updateService() {
    if (($('#txtNombreUpdate').val() != null && $('#txtNombreUpdate').val() != "")
        && ($('#txtValorHoraUpdate').val() != null && $('#txtValorHoraUpdate').val() != "")
        && ($('#clientToModify').val() != null && $('#clientToModify').val() != "")
        && ($('#serviceToModify').val() != null && $('#serviceToModify').val() != "")) {

        var service = new Object();
        service.Nombre = $('#txtNombreUpdate').val();
        service.ValorHora = $('#txtValorHoraUpdate').val();
        service.IdCliente = $('#clientToModify').val();

        $.ajax({
            type: 'PUT',
            url: urlServiceView + '?id=' + $('#serviceToModify').val(),
            data: service,
            success: function (data, textStatus, xhr) {
                $('#servicesTable').empty();
                cleanUpdateFields();
                AllServices();
                alert("Servicio modificado correctamente");
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

function cleanUpdateFields() {
    $('#txtNombreUpdate').val("");
    $('#txtValorHoraUpdate').val("");
    $('#IdCliente').val("");
}