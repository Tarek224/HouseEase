$(function () {
    $("#cityDev").hide();
    $("#facultyDev").hide();
    $("#governerate").change(function () {
        getAllCitiesByGovernerateId($(this).val(), "#city");
        $("#cityDev").show();
    });
    $("#university").change(function () {
        getAllFacultiesByUniversityId($(this).val(), "#faculty");
        $("#facultyDev").show();
    })
})

function getAllCitiesByGovernerateId(governerateId, selector) {
    $.ajax({
        url: "/Account/GetAllGouvernrateCities?gouvernrteId=" + governerateId ,
        type: "GET",
        datatype: "json",
        async: false,
        contentType: "application/json",
        success: function (res) {

            if (res.succeded) {
                console.log(res.content);
                $(selector).empty();
                $.each(res.content, function (i, city) {

                    $(selector).append(`<option value="${city.id}">${city.name} </option>`)
                })
            }
            else {
                failureToaster(res.message);
            }
        },
        error: function (err) {
            console.log("error: ", err)
        }
    });
}

function getAllFacultiesByUniversityId(universityId, selector) {
    $.ajax({
        url: "/Account/GetAllFacultiesByUniversityId?universityId=" + universityId,
        type: "GET",
        datatype: "json",
        async: false,
        contentType: "application/json",
        success: function (res) {

            if (res.succeded) {
                console.log(res.content);
                $(selector).empty();
                $.each(res.content, function (i, faculty) {

                    $(selector).append(`<option value="${faculty.id}">${faculty.name} </option>`)
                })
            }
            else {
                failureToaster(res.message);
            }
        },
        error: function (err) {
            console.log("error: ", err)
        }
    });
}
