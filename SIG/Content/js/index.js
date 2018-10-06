var working = false;
$('#login_autentication').on('submit', function (e) {
    e.preventDefault();
    if (working) return;
    working = true;
    var $this = $(this),
        $state = $this.find('button');
    $state.addClass('disabled');
    $state.html('Autenticando...');

    var dto = {
        Email: $("#edtEmail").val(),
        Senha: $("#edtSenha").val()
    };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: __path + 'Login/Authentication',
        data: { param: JSON.stringify(dto) },
        success: function (data) {
            var $state = $('#login_autentication').find('button');
            var $this = $('#login_autentication');
            if (data.status !== 200) {
                $state.html(data.message);
                setTimeout(function () {
                    $state.html('Acessar');
                    $this.removeClass('disabled');
                    working = false;
                }, 1000);
            } else {
                $state.html('Autorizado!');
                $state.removeClass('disabled');
                location.href = __path;
            }
        },
        error: function (error) {
            debugger;
        }
    })
});


$('.reset').on('submit', function (e) {
    e.preventDefault();
    if (working) return;
    working = true;
    var $this = $(this),
        $state = $this.find('button > .state');
    $this.addClass('loading');
    $state.html('Aguarde Solicitando...');

    var dto = {
        Email: $("#edtEmail").val()
    };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: __path + 'Login/Reset',
        data: { param: JSON.stringify(dto) },
        success: function (data) {
            var $state = $('.login').find('button > .state');
            var $this = $('.login');
            if (data.status != 200) {
                $this.addClass('error');
                $state.html(data.message);
                setTimeout(function () {
                    $state.html('Log in');
                    $this.removeClass('error ok loading');
                    working = false;
                }, 4000);
            } else {
                $this.addClass('ok');
                $state.html(data.message);

                swal({
                    title: "",
                    text: data.message,
                    type: "success",
                    html: true
                });

                setTimeout(function () {
                    location.href = __path;
                }, 2500);
            }
        },
        error: function (error) {
            debugger;
        }
    })
});