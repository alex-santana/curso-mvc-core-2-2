﻿function AjaxModal() {
    $(function () {
        $.ajaxSetup({ cache: false });

        $("a[data-modal]").on("click", function () {
                event.preventDefault();
                $('#myModalContent').load(this.href,
                    function () {
                        $('#myModal').modal({ keyboard: true }, 'show');
                        bindForm(this);
                    }
                );
            }
        );
    });

    function bindForm(dialog) {
        $("form", dialog).submit(function () {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $('#myModal').modal('hide');
                        $('#EnderecoTarget').load(result.url);
                    } else {
                        $('#EnderecoTarget').html(result);
                        bindForm(dialog);
                    }
                }
            });
            return false;
        });
    }
}
function BuscaCep() {
    $(document).ready(function () {
        function limpa_formulario_cep() {
            $("#Endereco_Logradouro").val("");
            $("#Endereco_Bairro").val("");
            $("#Endereco_Cidade").val("");
            $("#Endereco_Estado").val("");
        }

        $("#Endereco_Cep").blur(function () {
            var cep = $(this).val().replace(/\D/g, '');

            if (cep != "") {

                var validaCep = /^[0-9]{8}$/;

                if (validaCep.test(cep)) {
                    $("#Endereco_Logradouro").val("...");
                    $("#Endereco_Bairro").val("...");
                    $("#Endereco_Cidade").val("...");
                    $("#Endereco_Estado").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {
                            if (!("errro" in dados)) {

                                $("#Endereco_Logradouro").val(dados.logradouro);
                                $("#Endereco_Bairro").val(dados.bairro);
                                $("#Endereco_Cidade").val(dados.localidade);
                                $("#Endereco_Estado").val(dados.uf);
                                console.log(dados);
                            } else {
                                limpa_formulario_cep();
                                alert("Cep não encontrado");
                            }
                        });
                } else {
                    limpa_formulario_cep();
                    alert("Formato de CEP inválido");
                }

            }else {

                limpa_formulario_cep();
                
            }
        });
    });
}