var urlServiceView = '/api/Countries';

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

AllCountries();

function AllCountries() {
    $.ajax({
        url: urlServiceView,
        type: 'GET',
        data: JSON.stringify(),
        crossDomain: true,
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        success: function (data) {
            var table = '<table id="countriesTable" class="table table-bordered table-hover table-responsive">';
            table += ' <thead class="btn-primary"><tr><th>Id</th><th>Nombre</th></tr></thead>';

            $.each(data, function (key, item) {
                table += ('<tr>');
                table += ('<td>' + data[key].Id + '</td>');
                table += ('<td>' + data[key].Nombre + '</td>');
                table += ('</tr>');
            });

            table += '</table>';
            $("#tableContainer").html(table);
            var tableFilled = $("#countriesTable").DataTable({
                pageLength: 5,
                lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
                language: spanishLanguage,
                select: true
            });

        },
        error: function () {
            console.log('Countries not loaded');
        }
    });
}

function saveCountry() {
    if ($('#txtNombre').val() != null && $('#txtNombre').val() != "") {
        $.post(urlServiceView,
            {
                Nombre: $('#txtNombre').val()
            },
            function (data, status) {
                cleanSaveFields();
                AllCountries();
                alert("País creado correctamente");
            });
    }
    else
        alert("Debe diligenciar todos los campos");
}

function cleanSaveFields() {
    $('#txtNombre').val("");
}

function updateCountry() {
    if (($('#txtNombreUpdate').val() != null && $('#txtNombreUpdate').val() != "")
        && ($('#countryToUpdate').val() != null && $('#countryToUpdate').val() != "")) {

        var country = new Object();
        country.Nombre = $('#txtNombreUpdate').val();
        $.ajax({
            type: 'PUT',
            url: urlServiceView + '?id=' + $('#countryToUpdate').val(),
            data: country,
            success: function (data, textStatus, xhr) {
                $('#countriesTable').empty();
                cleanUpdateFields();
                AllCountries();
                alert("País modificado correctamente");
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
    $('#txtIdToUpdate').val("");
}