//Document ready
$(document).ready(function () {
    loadData();
    loadDataApi();
    loadNationalities();
    loadMajors();

    $("#btnModal").on("click", function () {
        $("#titleModal").html("Add Student");
    });

    $("table").on("click", ".btnUpdate", function () {
        $("#titleModal").html("Update Student");
        $('#error').text("");
    });



});
//Load nationalities from controller
function loadNationalities() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/Nationality/ListNationalities",
            data: "{}",
            success: function (data) {
                var s = '<option value="-1">Please Select</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].NationalityId + '">' + data[i].Name + '</option>';
                }
                $("#NationalitiesDropdown").html(s);
                $("#NationalityDApi").html(s);
            }
        });
    });
}
//Load majors from controller
function loadMajors() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/Major/ListMajors",
            data: "{}",
            success: function (data) {
                var s = '<option value="-1">Please Select</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].MajorId + '">' + data[i].Name + '</option>';
                }
                $("#MajorsDropdown").html(s);
                $("#MajorDApi").html(s);
            }
        });
    });
}

/*-------------------------------------------------------------
Methods from stored proceduress
-------------------------------------------------------------*/
//Load principal data
function loadData() {

    $.ajax({
        url: "/Student/ListAllSP",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            var html = '';
            $.each(result, function (key, item) {

                data = [
                    item.StudentId,
                    item.Name,
                    item.Age,
                    item.NationalityName,
                    item.MajorName,
                    item.Seniority,
                    item.EntryDate,
                    item.Interests,
                    '<td>'+
                    '<a class="" href="#"       onclick ="return GetById(' + item.StudentId + ')">Update</a>' +
                    ' | <a class="" href="#"    onclick="Delete(' + item.StudentId + ')"                    data-toggle="modal" data-target="#myModalDelete">Delete</a>' +
                    ' | <a class="" href="#"    onclick ="return GetByIdDetails(' + item.StudentId + ')"    data-toggle="modal" data-target="#myModalDetails">Details</a>' +
                    '</td >'
                ];

                dataSet.push(data);
            });
            $('#table').DataTable({
                "searching": false,
                data: dataSet,
                "bDestroy": true,
                responsive: true,
                scrollX: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]

            });

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}
//Get Data Datails
function GetByIdDetails(studentId) {
    $.ajax({
        url: "/Student/GetByIdSp/" + studentId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#StudentIdD').val(result.StudentId);
            $('#NameD').val(result.Name);
            $('#AgeD').val(result.Age);
            $("#NationalityD").val(result.NationalityName);
            $("#MajorD").val(result.MajorName);
            $("#SeniorityD").val(result.Seniority);
            $("#EntryDateD").val(result.EntryDate);
            $("#InterestsD").val(result.Interests);
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}
//Search a Student
function Search() {

    var name = $("#inputSearchStudent").val();
    if (name == "" || name.trim()=="")
    {
        loadData();
    }

    $.ajax({
        url: "/Student/GetStudentByName/",
        data: { name },
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            dataSet = new Array();
            var html = '';
            $.each(result, function (key, item) {

                data = [
                    item.StudentId,
                    item.Name,
                    item.Age,
                    item.NationalityName,
                    item.MajorName,
                    item.Seniority,
                    item.EntryDate,
                    item.Interests,
                    '<td>' +
                    '<a class="" href="#"       onclick ="return GetById(' + item.StudentId + ')">Update</a>' +
                    ' | <a class="" href="#"    onclick="Delete(' + item.StudentId + ')"                    data-toggle="modal" data-target="#myModalDelete">Delete</a>' +
                    ' | <a class="" href="#"    onclick ="return GetByIdDetails(' + item.StudentId + ')"    data-toggle="modal" data-target="#myModalDetails">Details</a>' +
                    '</td >'
                ];

                dataSet.push(data);
            });
            $('#table').DataTable({
                "searching": false,
                data: dataSet,
                "bDestroy": true,
                responsive: true,
                scrollX: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]

            });
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });


}
$(document).ready(function () {
    

    $("form").on("keyup", "#inputSearchStudent", function () {
        var nameSearch = $("#inputSearchStudent").val();
        if (nameSearch.trim() == "" || nameSearch == "")
        {
            loadData();
        }
        Search();
    });



});

/*-------------------------------------------------------------
Methods from API
-------------------------------------------------------------*/
function loadDataApi() {

    $.ajax({
        url: "/Student/ListAllApi",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            var html = '';
            $.each(result, function (key, item) {

                data = [
                    item.StudentId,
                    item.Name,
                    item.Age,
                    item.NationalityName,
                    item.MajorName,
                    item.Seniority,
                    item.EntryDate,
                    item.Interests,
                    '<td>' +
                    '<a class="" href="#"       onclick ="return GetByIdApi(' + item.StudentId + ')">Update</a>' +
                    ' | <a class="" href="#"    onclick="Delete(' + item.StudentId + ')"                    data-toggle="modal" data-target="#myModalDeleteApi">Delete</a>' +
                    ' | <a class="" href="#"    onclick ="return GetByIdDetailsApi(' + item.StudentId + ')"    data-toggle="modal" data-target="#myModalDetailsApi">Details</a>' +
                    '</td >'
                ];

                dataSet.push(data);
            });
            $('#tableApi').DataTable({
                "searching": false,
                data: dataSet,
                "bDestroy": true,
                responsive: true,
                scrollX: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]

            });

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}
//Get Data Datails
function GetByIdDetailsApi(studentId) {
    $.ajax({
        url: "/Student/GetByIdApi/" + studentId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#StudentIdDApi').val(result.StudentId);
            $('#NameDApi').val(result.Name);
            $('#AgeDApi').val(result.Age);
            $("select#NationalityDApi").val(result.Nationality);
            $("select#MajorDApi").val(result.Major);
            $("#SeniorityDApi").val(result.Seniority);
            $("#EntryDateDApi").val(result.EntryDate);
            $("#InterestsDApi").val(result.Interests);
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}
//Search a Student
function SearchApi() {

    var name = $("#inputSearchStudentApi").val();
    if (name == "" || name.trim() == "") {
        loadDataApi();
    }

    $.ajax({
        url: "/Student/GetStudentByNameApi/",
        data: { name },
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            dataSet = new Array();
            var html = '';
            $.each(result, function (key, item) {

                data = [
                    item.StudentId,
                    item.Name,
                    item.Age,
                    item.NationalityName,
                    item.MajorName,
                    item.Seniority,
                    item.EntryDate,
                    item.Interests,
                    '<td>' +
                    '<a class="" href="#"       onclick ="return GetByIdApi(' + item.StudentId + ')">Update</a>' +
                    ' | <a class="" href="#"    onclick="DeleteApi(' + item.StudentId + ')"                    data-toggle="modal" data-target="#myModalDeleteApi">Delete</a>' +
                    ' | <a class="" href="#"    onclick ="return GetByIdDetailsApi(' + item.StudentId + ')"    data-toggle="modal" data-target="#myModalDetailsApi">Details</a>' +
                    '</td >'
                ];

                dataSet.push(data);
            });
            $('#tableApi').DataTable({
                "searching": false,
                data: dataSet,
                "bDestroy": true,
                responsive: true,
                scrollX: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]

            });
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });


}
$(document).ready(function () {


    $("form").on("keyup", "#inputSearchStudentApi", function () {
        var nameSearch = $("#inputSearchStudentApi").val();
        if (nameSearch.trim() == "" || nameSearch == "") {
            loadDataApi();
        }
        SearchApi();
    });



});

/*-------------------------------------------------------------
Methods from tableRazor pagination
-------------------------------------------------------------*/
$(document).ready(function () {

    $('#TableRazor').DataTable({
        "searching": false,
        "bDestroy": true,
        responsive: true,
        scrollX: true,
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]

    });
});
/*-------------------------------------------------------------
Aditional methods for the Labs
-------------------------------------------------------------*/
//Add Data
function Add() {
    $("#modalTitle").text("Add Student");

    var nationality = {
        NationalityId: $("#NationalitiesDropdown option:selected").val()
    };
    var major = {
        MajorId: $("#MajorsDropdown option:selected").val()
    }
    var student = {
        //StudentId: $('#studentId').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        StudentNationality: nationality,
        StudentMajor: major
    };

    var inWhite = isNull(student);
    var errorMessage = "";

    if (inWhite.length == 0) {

        $.ajax({
            url: "/Student/AddSp",
            data: JSON.stringify(student),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                loadData();
                $('#myModal').modal('hide');

            },
            error: function (errorMessage) {
                console.log(errorMessage.responseText);
                alert(errorMessage.responseText);
            }
        })
    } else {
        for (i = 0; i < inWhite.length; i++) {
            errorMessage += inWhite[i] + ",";
        }
        $('#error').text("Empty spaces:" + errorMessage);
        errorMessage = "";
    }
}
//Update Data
function Update(student) {

    var nationality = {
        NationalityId: $("#NationalitiesDropdown option:selected").val()
    };

    var major = {
        MajorId: $("#MajorsDropdown option:selected").val()
    }

    var student = {
        StudentId: $('#StudentId').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        StudentNationality: nationality,
        StudentMajor: major
    };

    var inWhite = isNull(student);
    var errorMessage = "";

    if (inWhite.length == 0) {

        $.ajax({
            url: "/Student/UpdateSp",
            data: JSON.stringify(student),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData();
                $('#myModal').modal('hide');
            },
            error: function (errorMessage) {
                console.log(errorMessage.responseText);
                alert(errorMessage.responseText);
            }
        })
    } else {
        for (i = 0; i < inWhite.length; i++) {
            errorMessage += inWhite[i] + ",";
        }
        $('#error').text("Empty spaces:" + errorMessage);
        errorMessage = "";
    }

}
//Get Data
function GetById(studentId) {
    $.ajax({
        url: "/Student/GetByIdSp/" + studentId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#StudentId').val(result.StudentId);
            $('#Name').val(result.Name);
            $('#Age').val(result.Age);

            $("select#NationalitiesDropdown").val(result.NationalityId);

            $("#MajorsDropdown").val(result.MajorId);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}
//Delete Data
function Delete(id) {

    $(".modal").on("click", "button#btnDelete", function () {
        $.ajax({
            url: "/Student/DeleteSp/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
                $('#myModalDelete').modal('hide');

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });


}
//Control Data
function clearTextBox() {

    loadMajors();
    loadNationalities();

    $('#error').text("");

    $("#btnAdd").show();
    $("#btnUpdate").hide();

    $("#StudentId").val("");
    $("#Name").val("");
    $("#Age").val("");

}
function isNull(object) {

    var inWhite = [];
    var cont = 0;
    for (const property in object) {

        try {
            if (object[property].trim() == "") {
                inWhite[cont] = property;
                cont++;
            }
        } catch (error) {
        }
    }

    if ($("#NationalitiesDropdown option:selected").val() == -1) {
        inWhite.push("Nationality");
    }
    if ($("#MajorsDropdown option:selected").val() == -1) {
        inWhite.push("Major");
    }
    return inWhite;
}
