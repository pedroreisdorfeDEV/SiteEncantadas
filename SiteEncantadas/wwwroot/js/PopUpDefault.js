var TipoMsg = {
    SUCESSO: {
        valor: 0,
        classBtn: 'rs-btn-success',
        classAlert: 'success',
        classFechar: 'closePopUp'
    },
    AVISO: {
        valor: 1,
        classBtn: 'rs-btn-warning',
        classAlert: 'warning',
        classFechar: 'closePopUp'
    },
    ERRO: {
        valor: 2,
        classBtn: 'rs-btn-danger',
        classAlert: 'danger',
        classFechar: 'closePopUp'
    },
    CONFIRMACAO: {
        valor: 3,
        classNao: 'rs-btn-danger',
        classSim: 'rs-btn-success',
        classFechar: 'closePopUp'
    },
    INFORMATIVA: {
        valor: 4,
        //classNao: 'rs-btn-danger',
        classSim: 'rs-btn-success',
        classFechar: 'closePopUp'
    },
    CONFIRMAHORA: {
        valor: 5,
        classNao: 'rs-btn-danger',
        classSim: 'rs-btn-success',
        classFechar: 'closePopUp'
    },
    CARRINHO: {
        valor: 6,
        classFinalizar: 'rs-btn-danger',
        classFechar: 'closePopUp'
    },
    AVISOduasGuias: {
        valor: 7,
        classBtn: 'rs-btn-warning',
        classAlert: 'warning',
        classFechar: 'closePopUp'
    },
    SUCESSOcontinuar: {
        valor: 8,
        classBtn: 'rs-btn-success',
        classAlert: 'success',
        classFechar: 'closePopUp'
    },
    AVISOQRCODE: {
        valor: 9,
        classSim: 'rs-btn-success',
        classFechar: 'closePopUp'
    },
    TENTATIVASPIX: {
        valor: 10,
        classNao: 'rs-btn-danger',
        classSim: 'rs-btn-success',
        classAlert: 'success'
    },
    ESQUECEUsenha: {
        valor: 11,
        classBtn: 'rs-btn-success',
        classAlert: 'success',
        classFechar: 'closePopUp'
    },
    CONFIRMACAOpersonalizada: {
        valor: 12,
        classNao: 'rs-btn-danger',
        classSim: 'rs-btn-success'

    },
    CONFIRMACAOcodigo: {
        valor: 13,
        classNao: 'rs-btn-danger',
        classSim: 'rs-btn-success',
        classFechar: 'closePopUp'
    }
}

var TipoCadastro = {
    Geral: {
        valor: 0
    },
    Senha: {
        valor: 1
    }
}

var PopUp = function (opcoes) {
    var defaults = {
        mensagem: '',
        html: '',
        tipoMsg: null,
        fecharModal: true,
        fnConfirma: null,
        fnCancela: null,
        cadastro: null,
        esqueceuSenha: null,
        alterarSenha: null,
        inativo: null,
        botaoXconfirma: null,
        textos: {
            txtBtnDefault: 'Fechar',
            txtBtnSim: 'Sim',
            txtBtnEditar: 'Editar',
            txtBtnNao: 'Não',
            txtBtnVoltar: 'Voltar',
            txtBtnConfirmar: 'Confirmar',
            txtBtnFinalizar: 'Finalizar Compra',
            txtBtnManterGuia: 'Me manter nessa guia',
            txtBtnContinuar: 'Continuar',
            txtBtnRecuperarSenha: 'Recuperar senha',
            txtBtnAlterarSenha: 'Voltar para o início',
            txtBtnGerarQRCode: 'Gerar QRCode',
            txtConfirmarCodigo: 'Confirmar código',
            txtReeviarCodigo: 'Reenviar código',
            txtBtnFechar: 'X'
        }
    }

    defaults = $.extend(true, defaults, opcoes);

    // Valida mensagem
    if (IsEmpty(defaults.mensagem) && IsEmpty(defaults.html)) {
        throw new Error('É necessário uma Mensagem válida no método PopUp');
    }

    if (IsEmpty(defaults.tipoMsg)) {
        defaults.tipoMsg = TipoMsg.SUCESSO; // Tipo da mensagem - Default
    }
    //if (IsEmpty(defaults.tipoMsg)) {
    //    defaults.tipoMsg = TipoMsg.AVISOQRCODE; // Tipo da mensagem - Default
    //}

    // Opção de fechar do modal
    var modalHeader = $('<button>').attr('type', 'button').attr('id', 'btnHeader').attr('data-bs-dismiss', 'modal').attr('aria-hidden', 'true').addClass('close').append('&times;');
    // Button Fechar - Default
    var modalButton1 = $('<button>').attr('style', 'display: none;');
    // Button - Default
    var modalButton2 = $('<button>').css('display', 'none');
    var modalButton3 = $('<button>').css('display', 'flex');
    var valorInicialModalButton1 = modalButton1;
    var valorInicialModalButton2 = modalButton2;

    switch (defaults.tipoMsg.valor) {
        case TipoMsg.CONFIRMACAO.valor:
            // Button Não
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnNao').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classNao).append(defaults.textos.txtBtnNao);
            // Button Sim
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).append(defaults.textos.txtBtnSim);
            // Remove opção de fechar do modal
            modalHeader.text('');
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.INFORMATIVA.valor:
            // Button Não
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnNao').attr('data-bs-dismiss', 'modal').addClass('btn hidden').append(defaults.textos.txtBtnNao);
            // Button Sim
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).append(defaults.textos.txtBtnEditar);
            // Remove opção de fechar do modal
            modalHeader.text('');
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.CONFIRMAHORA.valor:
            // Button Voltar
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnVoltar').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classNao).append(defaults.textos.txtBtnVoltar);
            // Button Confirmar
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnConfirmar').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).append(defaults.textos.txtBtnConfirmar);
            // Remove opção de fechar do modal
            modalHeader.text('');
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.CARRINHO.valor:
            // Button Finalizar
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnFinalizar').attr('data-bs-dismiss', 'modal').attr('onclick', 'AbreCarrinho.Carrinho()').addClass('btn ' + defaults.tipoMsg.classFinalizar).append(defaults.textos.txtBtnFinalizar);
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.SUCESSO.valor:
            modalHeader.text('');
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.AVISOduasGuias.valor:
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnManterGuia').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classBtn).append(defaults.textos.txtBtnManterGuia);
            break;
        case TipoMsg.SUCESSOcontinuar.valor:
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnContinuar').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classBtn).append(defaults.alterarSenha != null ? defaults.textos.txtBtnAlterarSenha : defaults.textos.txtBtnContinuar);
            //close modal
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.AVISOQRCODE.valor:
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).addClass('botaoGerarQRCode').append(defaults.textos.txtBtnGerarQRCode);
            modalHeader.text('');
            //close modal
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.TENTATIVASPIX.valor:
            // Button Não
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnNao').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classNao).append(defaults.textos.txtBtnNao);
            // Button Sim
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).append(defaults.textos.txtBtnSim);
            break;
        case TipoMsg.ESQUECEUsenha.valor:
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnContinuarRecuperacao').addClass('btn ' + defaults.tipoMsg.classBtn).append(defaults.textos.txtBtnRecuperarSenha).attr('disabled', true);
            //close modal
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.CONFIRMACAOpersonalizada.valor:
            // Button Não
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnNao').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classNao).append(defaults.textos.txtBtnNao);
            // Button Sim
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).append(defaults.textos.txtBtnSim);
            // Remove opção de fechar do modal
            modalHeader.text('');
            //close modal
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.CONFIRMACAOpersonalizada.valor:
            // Button Não
            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnNao').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classNao).append(defaults.textos.txtBtnNao);
            // Button Sim
            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').attr('data-bs-dismiss', 'modal').addClass('btn ' + defaults.tipoMsg.classSim).append(defaults.textos.txtBtnSim);
        case TipoMsg.CONFIRMACAOcodigo.valor:

            modalButton2 = $('<button>').attr('type', 'button').attr('id', 'btnSim').addClass('btn ' + defaults.tipoMsg.classNao).addClass('botaoConfirma_Reenvio').append(defaults.textos.txtConfirmarCodigo);

            modalButton1 = $('<button>').attr('type', 'button').attr('id', 'btnNao').attr("onclick", "testeReenvio()").addClass('btn ' + defaults.tipoMsg.classSim).addClass('botaoConfirma_Reenvio').append(defaults.textos.txtReeviarCodigo);
            modalHeader.text('');
            break;
        case TipoMsg.AVISO.valor:
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        case TipoMsg.ERRO.valor:
            modalButton3 = $('<button>').attr('type', 'button').attr('data-bs-dismiss', 'modal').addClass(defaults.tipoMsg.classFechar).append(defaults.textos.txtBtnFechar).attr('aria-label', 'Fechar Modal');
            break;
        default:
            break;
    }


    // Criação do PopUp de mensagem
    if (defaults.tipoMsg.valor == TipoMsg.ERRO.valor) {
        CriacaoMsgPopUpErroProvisorio(modalButton3, modalButton1, modalButton2);
    }
    else if (defaults.tipoMsg.valor == TipoMsg.CARRINHO.valor) {
        CriacaoMsgPopUpCarrinho(modalButton3, modalButton1, modalButton2);
    }
    else if (defaults.cadastro != null) {
        CriacaoPopUpCadastro(modalHeader, modalButton1, modalButton2);
    }
    else if (defaults.esqueceuSenha != null) {
        CriacaoPopUpEsqueceuSenha(modalButton3, modalButton1, modalButton2);
    }
    else if (defaults.tipoMsg.valor == TipoMsg.TENTATIVASPIX.valor || defaults.tipoMsg.valor == TipoMsg.CONFIRMACAOpersonalizada.valor) {
        CriacaoPopUpPersonalizado(modalHeader, modalButton1, modalButton2);
    }
    else if (defaults.tipoMsg.valor == TipoMsg.CONFIRMACAOcodigo.valor) {
        CriacaoPopUpValidaCodigoEmail(modalButton3, modalButton1, modalButton2);
    }
    else {
        CriacaoMsgPopUp(modalButton3, modalButton1, modalButton2);
    }

    var isBtnSimENao = valorInicialModalButton2 != modalButton2 ? true : false;

    if (!isBtnSimENao && defaults.botaoXconfirma != false) {
        $('#imgXmensagem').click(function () {
            if (defaults.fnConfirma) {
                if (typeof (defaults.fnConfirma) !== 'function') {
                    throw new Error('É necessário uma função (fnConfirma) de retorno válida');
                }
                defaults.fnConfirma();
            }
        });
    }

    // Envento Click do Fechar e Sim
    $('#btnFechar, #btnSim, #btnConfirmar, #btnFinalizar, #btnManterGuia, #btnContinuar').click(function () {
        if (defaults.fnConfirma) {
            if (typeof (defaults.fnConfirma) !== 'function') {
                throw new Error('É necessário uma função (fnConfirma) de retorno válida');
            }
            defaults.fnConfirma();
        }
    });

    // Envento Click do Nao
    $('#btnNao, #btnVoltar').click(function () {
        if (defaults.fnCancela) {
            if (typeof (defaults.fnCancela) !== 'function') {
                throw new Error('É necessário uma função (fnCancela) de retorno válida');
            }
            defaults.fnCancela();
        }
    });
    // Evento Click do ?Finalizar
    $('#btnNao, #btnVoltar').click(function () {
        $('#menu').attr('style', 'visibility: hidden;');
        if (defaults.fnCancela) {
            if (typeof (defaults.fnCancela) !== 'function') {
                throw new Error('É necessário uma função (fnCancela) de retorno válida');
            }
            defaults.fnCancela();
        }
    });
    // Desativa a ação de close do modal
    if (!defaults.fecharModal) {
        $('#btnFechar, #btnSim').removeAttr('data-bs-dismiss');
    }

    $('body').attr('style', 'padding-right: 0px !important;');

    //PopUp que ao fechar da um reload na página
    function CriacaoPopUpPersonalizado(modalHeader, modalButton1, modalButton2) {
        // Remove se ouver outras divs ativadas, para nao ficar com duas fade
        $('div[class*=modal-backdrop]').remove();
        if (document.getElementById('loading-placeholder') != null) {
            $('#loading-placeholder').html('');
        }

        var titulo = defaults.inativo ? 'Você precisa ativar sua conta' : 'Atenção';

        $('#popUp-placeholder').html(
            '<div class="modal " id="popUpModal" focus="true" data-bs-keyboard="false" data-bs-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="popUpLabel" aria-hidden="true">' +
            '     <div class="modal-dialog modal-dialog-centered centerPopup">' +
            '         <div class="modal-content bodyPopup">' +
            `           <div class="modal-header tituloPopup">
                          <i>
                           <img class="imgPopup" src="/Content/img/Icons/alert.svg" onload="fetchSvg(this)">
                          </i>
                            <h4 class="modal-title titlePopup" id="popUpLabel"><strong>${titulo}</strong></h4>
                            
                        </div> `+
            `             <hr class="linhaDivisoria-popUp">          ` +
            '             <div class="modal-body textoPopup">' +
            '                 <label for="mensagem" class="mensagemPopup">' + defaults.mensagem.replace(new RegExp('\n', 'g'), '<br/>') + '</label>' +
            defaults.html +
            '             </div>' +
            '             <div class="modal-footer btnfooter">' +
            modalButton1[0].outerHTML +
            modalButton2[0].outerHTML +
            '             </div>' +
            '         </div>' +
            '     </div>' +
            '</div>'
        )



        // Show no modal
        $('#popUpModal').modal('show');

        modalButton1 == valorInicialModalButton1 && modalButton2 == valorInicialModalButton2 ? $('.imgPopupX').attr('style', 'display: block') : "";
        valorInicialModalButton2 == modalButton2 ? $('.btnfooter').attr('style', 'justify-content: center !important;') : "";
        TipoMsg.AVISOduasGuias.valor ? $('#imgXmensagem').attr('style', 'display: block;') : "";

        if (defaults.inativo) {
            $('.titlePopup').css('margin', '0');
            $('.tituloPopup i').css('display', 'none');
            $('.tituloPopup').css('justify-content', 'center');
            $('.tituloPopup').css('padding-bottom', '.4rem');
        }
    }

    function CriacaoMsgPopUp(modalButton3, modalButton1, modalButton2) {

        // Remove se ouver outras divs ativadas, para nao ficar com duas fade
        $('div[class*=modal-backdrop]').remove();
        if (document.getElementById('loading-placeholder') != null) {
            $('#loading-placeholder').html('');
        }

        var titulo = defaults.inativo ? 'Você precisa ativar sua conta' : 'Atenção';

        $('#popUp-placeholder').html(
            '<div class="modal " id="popUpModal" focus="true" data-bs-keyboard="false" data-bs-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="popUpLabel" aria-hidden="true">' +
            '     <div class="modal-dialog modal-dialog-centered centerPopup">' +
            '         <div class="modal-content bodyPopup">' +
            `           <div class="modal-header tituloPopup">
                          <i>
                           <img class="imgPopup" src="/Content/img/Icons/alert.svg" onload="fetchSvg(this)">
                          </i>
                            <h4 class="modal-title titlePopup" id="popUpLabel"><strong>${titulo}</strong></h4>
                             <div id="imgXmensagem" onclick="closeModal()" class="imgPopupX" style="display: none">` + modalButton3[0].outerHTML +
            `                </div>
                        </div> `+
            `             <hr class="linhaDivisoria-popUp">          ` +
            '             <div class="modal-body textoPopup">' +
            '                 <label for="mensagem" class="mensagemPopup textPersonalizado">' + defaults.mensagem.replace(new RegExp('\n', 'g'), '<br/>') + '</label>' +
            defaults.html +
            '             </div>' +
            '             <div class="modal-footer btnfooter">' +
            modalButton1[0].outerHTML +
            modalButton2[0].outerHTML +
            '             </div>' +
            '         </div>' +
            '     </div>' +
            '</div>'
        )
        // Show no modal
        $('#popUpModal').modal('show');


        modalButton1 == valorInicialModalButton1 && modalButton2 == valorInicialModalButton2 ? $('.imgPopupX').attr('style', 'display: block') : "";
        valorInicialModalButton2 == modalButton2 ? $('.btnfooter').attr('style', 'justify-content: center !important;') : "";
        TipoMsg.AVISOduasGuias.valor ? $('#imgXmensagem').attr('style', 'display: block;') : "";

        if (defaults.inativo) {
            $('.titlePopup').css('margin', '0');
            $('.tituloPopup i').css('display', 'none');
            $('.tituloPopup').css('justify-content', 'center');
            $('.tituloPopup').css('padding-bottom', '.4rem');
        }

        if (defaults.alterarSenha) {
            $('#btnContinuar').attr('style', 'width: 10rem;');
        }
    }
    function CriacaoMsgPopUpCarrinho(modalButton3, modalButton1, modalButton2) {
        // Remove se ouver outras divs ativadas, para nao ficar com duas fade
        $('div[class*=modal-backdrop]').remove();
        if (document.getElementById('loading-placeholder') != null) {
            $('#loading-placeholder').html('');
        }
        $('#popUp-placeholder').html(
            '<div class="modal " id="popUpModal" focus="true" data-bs-keyboard="false" data-bs-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="popUpLabel" aria-hidden="true">' +
            '     <div class="modal-dialog modal-dialog-centered centerPopup">' +

            '         <div class="modal-content bodyPopup modalCarrinho" style="width: 80%;">' +
            '             <div class="modal-header tituloPopup tituloCarrinho" id="fechaModal">' +
            '                 <h4 class="modal-title titlePopup" id="popUpLabel" style="margin-left: 0px;"><strong> Meu Carrinho</strong></h4>' +
            `               <div onclick="closeModal()" class="imgPopupX">` + modalButton3[0].outerHTML +
            `               </div>
                         </div> `+
            `             <hr class="linhaDivisoria-popUp">          ` +
            '             <div class="modal-body textoPopup modal-bodyCarrinho">' +
            '                 <label for="mensagem" class="mensagemPopup">' + defaults.mensagem + '</label>' +
            defaults.html +
            '             </div>' +
            '             <div class="modal-footer btnfooter modal-footerCarrinho">' +
            modalButton1[0].outerHTML +
            modalButton2[0].outerHTML +
            '             </div>' +
            '         </div>' +
            '     </div>' +
            '</div>'
        )
        // Show no modal
        $('#popUpModal').modal('show');
    }

    function CriacaoMsgPopUpErroProvisorio(modalButton3, modalButton1, modalButton2) {
        // Remove se ouver outras divs ativadas, para nao ficar com duas fade
        $('div[class*=modal-backdrop]').remove();

        $('#popUp-placeholder').html(
            '<div class="modal " id="popUpModal" data-bs-keyboard="false" data-bs-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="popUpLabel" aria-hidden="true">' +
            '   <div class="modal-dialog modal-dialog-centered">' +
            '       <div class="modal-content bodyPopup" style="color: var(--cor-atencao)">' +
            '          <div style="align-self: center;">' +
            '             <div class="col-12" style="margin: 0;">' +
            `               <div class="divTituloPopUp-BtnClose" style="border-bottom: 1px solid #dee2e6; margin: 0; margin-bottom: 0.5rem;">
                              <span class="row titlePopup" style="color: var(--cor-primaria) !important; justify-content: center; text-align: center;">
                                  Ops, ocorreu um erro!
                              </span>
                            <div  onclick="closeDoModal()" class="imgPopupX">` + modalButton3[0].outerHTML +
            `                </div>
                            </div> `+
            '                  <p class="spanMsgErro" style="justify-content: center; color: var(--cor-font-scape-secundaria);">' +
            defaults.mensagem.replace(new RegExp('\n', 'g'), '<br/>') + defaults.html +
            '                  </p> ' +
            '             </div>' +
            '           </div>' +
            '       <div class="modal-footer">' +
            modalButton1[0].outerHTML +
            modalButton2[0].outerHTML +
            '       </div>' +
            '       </div>' +
            '    </div>' +
            '</div>'
        )
        $('#popUpModal').modal('show');
    }

    function CriacaoPopUpCadastro(modalHeader, modalButton1, modalButton2) {
        $('div[class*=modal-backdrop]').remove();

        var titulo = defaults.cadastro.valor == 0 ? "Cadastro atualizado com sucesso!" : "Senha atualizada com sucesso!";

        $('#popUp-placeholder').html(
            `<div class="modal" id="popUpModal" data-bs-backdrop="static">
                 <div class="modal-dialog modal-dialog-centered centerPopup">
                    <div class="modal-content bodyPopup" id="modalContent-cadastro">
                        <div class="modal-header tituloPopup tituloPopup-cadastro">
                            <h4 class="modal-title titlePopup titlePopup-cadastro" id="popUpLabel">
                                ${titulo}
                           </h4>
                        </div>         
                        <div class="modal-body textoPopup">
                            <label for="mensagem" class="mensagemPopup msgCadastro">
                                <span>Como medida de segurança enviamos uma notificação de atualização para
                                    <strong>
                                        ${defaults.mensagem}
                                   </strong>
                                <span>
                            </label>
                        </div>
                        <div class="modal-footer btnfooter" id="div-btnFooter">
                            ${modalButton1[0].outerHTML}
                       </div> 
                     </div>
                 </div>
           </div> `
        )
        // Show no modal
        $('#popUpModal').modal('show');
        $('#btnContinuar').addClass('btnContinuar-cadastro');
    }

    function CriacaoPopUpEsqueceuSenha(modalHeader, modalButton1, modalButton2) {
        $('div[class*=modal-backdrop]').remove();

        $('#popUp-placeholder').html(
            `<div class="modal" id="popUpModal" data-bs-backdrop="static">
                 <div class="modal-dialog modal-dialog-centered centerPopup">
                    <div class="modal-content bodyPopup" id="modalContent-recuperacao">
                        <div class="modal-header tituloPopup tituloPopup-recuperacao">
                            <h4 class="modal-title titlePopup " id="popUpLabel">
                                Esqueceu a senha de acesso?
                           </h4>
                            <div  onclick="closeModal()" class="imgPopupX">
                              <img class="imgPopupX" src="/Content/img/Icons/x.svg" onload="fetchSvg(this)" alt="Ops, Ocorreu um erro!">
                            </div>
                        </div>         
                        <div class="modal-body textoPopup">
                            <label for="mensagem" class="mensagemPopup msgRecuperacao">
                                <span id="fraseAntesRecuperacao">
                                    Informe seu número do CPF ou CNPJ caadastrado
                                </span>
                                <span id="fraseAposRecuperacao" style="display: none;">
                                    Para recuperarmos sua senha, enviaremos um link para o e-mail cadastrado. Acesse sua caixa de entrada para finalizar a operação.
                                </span>
                            </label>
                            <form class="inputRecuperacaoSenha">
                                <input
                                    class="boxInputRecuperacao" id="docUsuario"
                                    autocomplete="false" placeholder="CPF ou CNPJ" oninput="validarInputRecuperacao(id)" maxlength = "14">
                                <p class="boxInputRecuperacao" id="docUsuarioSucessoRecuperacao" hidden></p>
                                <div class="usuarioNaoEncontrado" style="display: none;">
                                    <img class="imgPopup" src="/Content/img/Icons/alertEsqueceuSenha.svg" onload="fetchSvg(this)">
                                    <span>CPF ou CNPJ não encontrado</span>
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer btnfooter" id="div-btnFooter">
                            ${modalButton1[0].outerHTML}
                       </div> 
                     </div>
                 </div>
           </div> `
        )
        // Show no modal
        $('#popUpModal').modal('show');
        $('#btnContinuarRecuperacao').attr("onclick", "continuarEsqueceuSenha()");
        document.addEventListener("keydown", function (e) {
            if (e.keyCode === 13 && defaults.esqueceuSenha) {
                e.preventDefault();
                if ($('#docUsuario').val() != "" && typeof $('#docUsuario').val() !== "undefined") {
                    if ($('#docUsuario').val().length > 10 && $('#docUsuario').prop("disabled") != true) {
                        $('#btnContinuarRecuperacao').click();
                    }
                }
            }
        });
    }
    // nova função
    function CriacaoPopUpValidaCodigoEmail(modalButton3, modalButton1, modalButton2) {
        // Remove se ouver outras divs ativadas, para nao ficar com duas fade
        $('div[class*=modal-backdrop]').remove();
        if (document.getElementById('loading-placeholder') != null) {
            $('#loading-placeholder').html('');
        }

        var titulo = 'Atenção';

        $('#popUp-placeholder').html(
            '<div class="modal " id="popUpModal" focus="true" data-bs-keyboard="false" data-bs-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="popUpLabel" aria-hidden="true">' +
            '     <div class="modal-dialog modal-dialog-centered centerPopup">' +
            '         <div class="modal-content bodyPopup">' +
            `           <div class="modal-header tituloPopup">
                          <i>
                           <img class="imgPopup" src="/Content/img/Icons/alert.svg" onload="fetchSvg(this)">
                          </i>
                            <h4 class="modal-title titlePopup" id="popUpLabel"><strong>${titulo}</strong></h4>
                             <div id="imgXmensagem" onclick="closeModal()" class="imgPopupX" style="display: none">
                                `+ modalButton3[0].outerHTML + `
                            </div>
                        </div> `+
            `             <hr class="linhaDivisoria-popUp">          ` +
            '             <div class="modal-body textoPopup">' +
            '                 <label for="mensagem" class="mensagemPopup">' + defaults.mensagem.replace(new RegExp('\n', 'g'), '<br/>') + '</label>' +
            defaults.html +
            '             </div>' + `<div class="inputCodigoDiv">
                                        <div class="divInputCod">
                                            <input class="inputCodigo" id="codigoDeValidacao" value="" maxlength="6" onclick="mudaInput()"/>
                                        </div>
                                        <div>
                                            <span class="codigoInvalido">Código Inválido</span>
                                        </div>
                                    </div>`
            +
            '             <div class="modal-footer btnfooter divBotoes">' +
            '<div style="display:flex; flex-direction: column;">' + modalButton1[0].outerHTML + '</div>' +
            modalButton2[0].outerHTML +
            '             </div>' + '<div class="divParaLooping"><div class="loadingPersonalizadoPop" id="loadingDoBootstrap"><div class="spinner-border" role="status"><span class="visually-hidden"></span></div></div></div>' + '<div class= "codigoReenviado" id="codReenviado"><span > Código reenviado!</span></div>' +
            '         </div>' +
            '     </div>' +
            '</div>'
        )
        // Show no modal
        $('#popUpModal').modal('show');

        modalButton1 == valorInicialModalButton1 && modalButton2 == valorInicialModalButton2 ? $('.imgPopupX').attr('style', 'display: block') : "";
        valorInicialModalButton2 == modalButton2 ? $('.btnfooter').attr('style', 'justify-content: center !important;') : "";
        TipoMsg.AVISOduasGuias.valor ? $('#imgXmensagem').attr('style', 'display: block;') : "";

        if (defaults.inativo) {
            $('.titlePopup').css('margin', '0');
            $('.tituloPopup i').css('display', 'none');
            $('.tituloPopup').css('justify-content', 'center');
            $('.tituloPopup').css('padding-bottom', '.4rem');
        }
    }

}

function validarInputRecuperacao(id) {
    $('#docUsuario').removeClass('naoEncontrado');
    $('.usuarioNaoEncontrado').attr('style', 'display: none');

    var inputRecuperacao = $('#' + id).val();

    if (inputRecuperacao.length > 10) {
        $('#btnContinuarRecuperacao').prop('disabled', false);
    }
    else {
        $('#btnContinuarRecuperacao').prop('disabled', true);
    }
}

function usuarioNaoEncontrado() {
    $('#docUsuario').addClass('naoEncontrado');
    $('.usuarioNaoEncontrado').removeAttr('style', 'display: none');
    $('#btnContinuarRecuperacao').prop('disabled', true);

}

function sucessoRecuperacaoSenha(retorno) {
    var email = retorno;
    var nomeUsuario = email.split("@")[0].substring(0, 3) + "...";
    var ocultarDominio = email.split("@")[1].substring(0, email.split("@")[1].indexOf(".")).substring(0, 3) + "...";
    var valoresFinaisEmail = email.split("@")[1].split(".").slice(1);
    var valoresFinaisEmailJuntados = valoresFinaisEmail.join(".");
    $('#docUsuarioSucessoRecuperacao').text(nomeUsuario + "@" + ocultarDominio + valoresFinaisEmailJuntados);

    $('#docUsuarioSucessoRecuperacao').addClass('sucessoRecuperacaoSenha');
    $("#docUsuario").prop("disabled", true);
    $("#docUsuario").prop("hidden", "hidden");
    $("#docUsuarioSucessoRecuperacao").removeAttr("hidden", "hidden");
    $("#fraseAntesRecuperacao").attr("style", "display: none;");
    $("#fraseAposRecuperacao").removeAttr("style", "display: none;");
    $("#btnContinuarRecuperacao").attr("style", "display: none");
    $("#popUpLabel").html("Recuperação de senha");
}

function closeModal() {
    $('#popUpModal').modal('hide');

}

function closeDoModal() {
    location.reload();
}


var AlertInDiv = function (opcoes) {

    var defaults = {
        mensagem: null,
        tipoMsg: null,
        div: null,
        tempo: null
    }

    defaults = $.extend({}, defaults, opcoes);

    if (IsEmpty(defaults.tipoMsg)) {
        defaults.tipoMsg = TipoMsg.AVISO; // Tipo da mensagem - Default
    }

    var random = Math.floor((Math.random() * 1000) + 1);
    //Sets the alert inside the alert place holder
    defaults.div.html(
        '<div id="divAlertInDiv' + random + '" class="alert alert-' + defaults.tipoMsg.classAlert + ' alert-dismissable" style="text-align:left; z-index:999">' +
        '   <button type="button" class="close" data-bs-dismiss="alert" aria-hidden="true">&times;</button>' +
        '   ' + defaults.mensagem +
        '</div>'
    );
    setTimeout('$("#divAlertInDiv' + random + '").hide()', IsEmpty(defaults.tempo) ? 8000 : defaults.tempo);
}

$('#codigoDeValidacao').click(function () {
    $(".inputCodigo").attr("style", "border-bottom: 1px solid var(--cor-primaria); background-color: white");
});

