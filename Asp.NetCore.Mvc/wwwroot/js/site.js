// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".editor").trumbowyg({
    lang: 'ko',
    btnsDef: {
        image: {
            dropdown: ['insertImage', 'upload'],    // 기존 insertImage를 upload로 변경
            ico:'insertImage'
        }
    },
    btns: [
        ['viewHTML'],
        ['formatting'],
        ['strong', 'em', 'del'],
        ['superscript', 'subcript'],
        ['link'],
        'image',    // upload용 버튼
        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']
    ]
});