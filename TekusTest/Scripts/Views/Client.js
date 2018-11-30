var urlServiceView = '/api/Clients';

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

    $("#cliente").change(function () {
        $("#servicios").empty();
        if ($("#cliente").val() != null && $("#cliente").val() != "") {
            $.ajax({
                type: 'POST',
                url: '@Url.Action("getService")',
                dataType: 'json',
                data: { id: $("#cliente").val() },
                success: function (services) {
                    $.each(services, function (i, service) {
                        $("#servicios").append('<option value="' + service.Value + '">' +
                            service.Text + '</option>');
                    });
                },
                error: function (ex) {
                    alert('No se pudo obtener los servicios relacionados con el cliente.' + ex);
                }
            });
        }

        return false;
    });
});

AllClients();

function OnChangeService() {
    alert($("#servicios").val());
}

function AllClients() {
    $.ajax({
        url: urlServiceView,
        type: 'GET',
        data: JSON.stringify(),
        crossDomain: true,
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        success: function (data) {
            var table = '<table id="clientsTable" class="table table-bordered table-hover table-responsive">';
            table += ' <thead class="btn-primary"><tr><th>Nit</th><th>Nombre</th><th>Email</th></tr></thead>';

            $.each(data, function (key, item) {
                table += ('<tr>');
                table += ('<td>' + data[key].Nit + '</td>');
                table += ('<td>' + data[key].Nombre + '</td>');
                table += ('<td>' + data[key].Email + '</td>');
                table += ('</tr>');
            });

            table += '</table>';
            $("#tableContainer").html(table);
            var tableFilled = $("#clientsTable").DataTable({
                pageLength: 5,
                lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
                language: spanishLanguage,
                select: true
            });

        },
        error: function () {
            console.log('Cients not loaded');
        }
    });
}

function saveClient() {
    if (($('#txtNit').val() != null && $('#txtNit').val() != "")
        && ($('#txtNombre').val() != null && $('#txtNombre').val() != "")
        && ($('#txtEmail').val() != null && $('#txtEmail').val() != "")) {
        $.post(urlServiceView,
            {
                Nit: $('#txtNit').val(),
                Nombre: $('#txtNombre').val(),
                Email: $('#txtEmail').val()
            },
            function (data, status) {
                cleanSaveFields();
                AllClients();
                alert("Cliente creado correctamente");
            });
    }
    else
        alert("Debe diligenciar todos los campos");
}

function cleanSaveFields() {
    $('#txtNit').val("");
    $('#txtNombre').val("");
    $('#txtEmail').val("");
}

function updateClient() {
    if (($('#txtNitUpdate').val() != null && $('#txtNitUpdate').val() != "")
        && ($('#txtNombreUpdate').val() != null && $('#txtNombreUpdate').val() != "")
        && ($('#txtEmailUpdate').val() != null && $('#txtEmailUpdate').val() != "")
        && ($('#txtNitClientToUpdate').val() != null && $('#txtNitClientToUpdate').val() != "")) {

        var client = new Object();
        client.Nit = $('#txtNitUpdate').val();
        client.Nombre = $('#txtNombreUpdate').val();
        client.Email = $('#txtEmailUpdate').val();
        $.ajax({
            type: 'PUT',
            url: urlServiceView + '?id=' + $('#txtNitClientToUpdate').val(),
            data: client,
            success: function (data, textStatus, xhr) {
                $('#clientsTable').empty();
                cleanUpdateFields();
                AllClients();
                alert("Cliente modificado correctamente");
            },
            error: function (xhr, textStatus, errorThrown) {
                if (xhr.status == 400) {
                    alert("El Nit ingresado no se encuentra en el sistema");
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
    $('#txtNitUpdate').val("");
    $('#txtNombreUpdate').val("");
    $('#txtEmailUpdate').val("");
    $('#txtNitClientToUpdate').val("");
}