

function SaveAjax(destination, jsonData) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: destination,
            type: "post",
            data: jsonData,
            contentType: "application/json",
            success: function (response) {
                resolve(response);
            },
            error: function (response) {
                reject(response);
            }
        });
    });
}

const Save = async () => {
    try {
        let formData = new FormData($("#createPatient")[0]);
        const url = "/api/PatientInformation/AddPatient";
        const formObject = {};
        formData.forEach((value, key) => {

            if (formObject[key]) {
                if (!Array.isArray(formObject[key])) {
                    formObject[firstLetterLowerCase(key)] = [formObject[key]];
                }
                formObject[firstLetterLowerCase(key)].push(value);
            } else {
                formObject[firstLetterLowerCase(key)] = value;
            }
        });

        let response = await SaveAjax(url, JSON.stringify(formObject));
        if (typeof (response) == "object") {
            alert("Patient added succesfully");
            window.location.reload();
        } else {
            alert("Something went wrong!");
        }
    } catch (e) {
        alert("Something went wrong!");
    }
}
$(document).ready(function () {
    const url = "/api/PatientInformation/GetAllList";
    GetAjax(url).then(response => {

    })
});
function firstLetterLowerCase(str) {
    if (!str) return str;
    return str.charAt(0).toLowerCase() + str.slice(1);
}

function GetAjax(destination) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: destination,
            method: "GET",
            dataType: "JSON",
            success: function (response) {
                const dropdown = $('#fromNCD');
                dropdown.empty();
                const diseaseDropdown = $('#DiseaseId');
                diseaseDropdown.empty();
                const allergiesDropdown = $('#fromAllergies');
                allergiesDropdown.empty();

                $.each(response.ncDs, function (index, item) {
                    $('<option>', {
                        value: item.value,
                        text: item.text
                    }).appendTo(dropdown);
                });
                $.each(response.diseases, function (index, item) {
                    $('<option>', {
                        value: item.value,
                        text: item.text
                    }).appendTo(diseaseDropdown);
                });
                $.each(response.allergies, function (index, item) {
                    $('<option>', {
                        value: item.value,
                        text: item.text
                    }).appendTo(allergiesDropdown);
                });

            },
            error: function (response) {

            }
        });
    });
}

$("#save").click(function () {
    Save();
});





$('#addAllergies').click(function () {
    var selectedValue = $('#fromAllergies').val();
    var selectedText = $('#fromAllergies option:selected').text();

    if (selectedValue) {
        $('#toAllergies').append(new Option(selectedText, selectedValue));
        $('#fromAllergies option:selected').remove();
        updateSelectedAllergies();
    }
});

$('#removeAllergies').click(function () {
    var selectedValue = $('#toAllergies').val();
    var selectedText = $('#toAllergies option:selected').text();

    if (selectedValue) {
        $('#fromAllergies').append(new Option(selectedText, selectedValue));
        $('#toAllergies option:selected').remove();
        updateSelectedAllergies();
    }
});

function updateSelectedAllergies() {
    var selecteAllergies = [];
    $('#toAllergies option').each(function () {
        selecteAllergies.push($(this).val());
    });
    $('input[name="SelectedAllergies"]').val(selecteAllergies.join(','));
}


$('#addNCD').click(function () {
    var selectedValue = $('#fromNCD').val();
    var selectedText = $('#fromNCD option:selected').text();

    if (selectedValue) {
        $('#toNCD').append(new Option(selectedText, selectedValue));
        $('#fromNCD option:selected').remove();
        updateSelectedNCDs();
    }
});

$('#removeNCD').click(function () {
    var selectedValue = $('#toNCD').val();
    var selectedText = $('#toNCD option:selected').text();

    if (selectedValue) {
        $('#fromNCD').append(new Option(selectedText, selectedValue));
        $('#toNCD option:selected').remove();
        updateSelectedNCDs();
    }
});

function updateSelectedNCDs() {
    var selectedNCDs = [];
    $('#toNCD option').each(function () {
        selectedNCDs.push($(this).val());
    });
    $('input[name="SelectedNCDs"]').val(selectedNCDs.join(','));
}

