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
        progressSteps: ['1', '2', '3', '4']
    }).queue([
        {
            title: 'Passo 1:',
            text: 'Selecione um arquivo com formato .xls ou .xlsx, sendo a primeira coluna obrigatoriamente '
                + 'com o Telefone no formato "11123456789", a segunda com o Nome, + 5 colunas (ou menos) com variáveis de sua escolha...',
            imageUrl: '/help/ex1.png'
        },
        {
            title: 'Passo 2:',
            html: 'Preencha o campo "Script" com uma mensagem substuindo as variáveis abaixo pelos respectivos campos do documento adicionado:<p>' 
                + '<li>{0} = Número;</li> '
                + '<li>{1} = Nome; </li>'
                + '<li>{2} = Coluna1;</li> '
                + '<li>{3} = Coluna2; </li>'
                + '<li>{4} = Coluna3; </li>'
                + '<li>{5} = Coluna4; </li>'
                + '<li>{6} = Coluna5;</li>'
        },
        {
            title: 'Variáveis substiuídas:',
            imageUrl: '/help/ex2.png'
        },
        {
            title: 'Olha que beleza!',
            imageUrl: '/help/ex3.png'
        },
        
    ])
}

function uploadstatus(icon, title) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        onOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: icon,
        title: title
    })
}