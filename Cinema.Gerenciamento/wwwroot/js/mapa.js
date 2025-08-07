$(document).ready(function () {
    var poltronaIdAtual;

    // Lógica para lidar com o clique na poltrona
    $('.poltrona').click(function () {
        poltronaIdAtual = $(this).data('poltrona-id');
        var poltronaStatus = $(this).data('status');
        var poltronaNumero = $(this).text();

        $('#modalPoltronaNumero').text(poltronaNumero);
        $('#modalPoltronaStatus').text(poltronaStatus);

        // Armazena o ID no modal para usar nas ações
        $('#poltronaModal').data('poltrona-id', poltronaIdAtual);

        $('#poltronaModal').modal('show');
    });

    // Lógica para o botão "Liberar Poltrona"
    $('#btnLiberarPoltrona').click(function () {
        var poltronaId = $('#poltronaModal').data('poltrona-id');
        // Chamada AJAX para o Controller
        $.ajax({
            url: '/Sala/AlterarStatusPoltrona',
            type: 'POST',
            data: { poltronaId: poltronaId, novoStatus: "Livre" },
            success: function (result) {
                if (result.success) {
                    alert('Poltrona liberada com sucesso!');
                    location.reload(); 
                }
            },
            error: function (xhr, status, error) {
                alert('Erro ao liberar a poltrona. Tente novamente.');
            }
        });
    });

    // Lógica para o botão "Registrar Penalização"
    $('#btnRegistrarPenalizacao').click(function () {
        var poltronaId = $('#poltronaModal').data('poltrona-id');
        // Chamada AJAX para o Controller
        $.ajax({
            url: '/Sala/RegistrarPenalizacao', // Você precisará criar esta action
            type: 'POST',
            data: { poltronaId: poltronaId },
            success: function (result) {
                if (result.success) {
                    alert('Penalização registrada com sucesso!');
                    location.reload(); 
                }
            },
            error: function (xhr, status, error) {
                alert('Erro ao registrar a penalização. Tente novamente.');
            }
        });
    });
});