$(document).ready(function () {
    const inputFields = $('#soLuong, #donGia');
    inputFields.on('input', function () {
        let inputValue = $(this).val().replaceAll(",", "").replaceAll(/[^0-9]/g, "");
        if (inputValue.length === 0) {
            $(this).val('');
        } else if (inputValue.length === 1) {
            let number = parseInt(inputValue);
            if (isNaN(number) || number <= 0) {
                number = 1;
            }
            $(this).val(number.toLocaleString('en-US'));
        } else {
            $(this).val(parseInt(inputValue).toLocaleString('en-US'));
        }
    });
});

