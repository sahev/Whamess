async function uploadbtn() {

    const { value: file } = await Swal.fire({
        title: 'Select image',
        input: 'file',
        inputAttributes: {
            'accept': 'xlsx/*',
            'aria-label': 'Upload your file'
        }
    })

    if (file) {
        const reader = new FileReader()
        reader.onload = (e) => {
            Swal.fire({
                title: 'Your uploaded picture',
                imageUrl: e.target.result,
                imageAlt: 'The uploaded picture'
            })
        }
        reader.readAsDataURL(file)
    }

}

function campaignsuccess() {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Mensagens enviadas com sucesso!',
        showConfirmButton: false,
        timer: 4000
    })
}

function campaigninsuccess() {
    Swal.fire({
        position: 'top-end',
        icon: 'warning',
        title: 'Preencha o campo "Script" com a sua mensagem!',
        showConfirmButton: false,
        timer: 4000
    })
}

function info() {
    Swal.mixin({
     
        confirmButtonText: 'Next &rarr;',
        showCancelButton: false,
        progressSteps: ['1', '2', '3']
    }).queue([
        {
            title: 'Passo 1:',
            text: 'Selecione um arquivo com formato .xls ou .xlsx'
        },
        {
            title: 'Passo 2:',
            html: 'Preencha o campo "Script" com uma mensagem substuindo as variáveis abaixo pelos respectivos campos do documento adicionado:<p>' 
                + '<p>{0} = Número; '
                + '<p>{1} = Nome; '
                + '<p>{2} = Variável1; '
                + '<p>{3} = Variável2; '
                + '<p>{4} = Variável3; '
                + '<p>{5} = Variável4; '
                + '<p>{6} = Variável5;'
        },
        {
            title: 'Passo 3:',
            text: 'Selecione o arquivo;'
        },
    ])
}

