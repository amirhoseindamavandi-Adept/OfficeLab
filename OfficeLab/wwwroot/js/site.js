function StartLoading(element = 'body') {
    $(element).waitMe({
        effect: 'bounce',
        text: 'لطفا منتظر بمانید',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function CloseLoading(element = 'body') {
    $(element).waitMe('hide');
}

function LoadEmployeeModalBody(EmployeeId) {
    $.ajax({
        url: "/load-employee-modal-body",
        type: "get",
        data: {
            EmployeeId: EmployeeId
        },
        beforeSend: function () {
            StartLoading();
        },
        success: function (response) {
            CloseLoading();
            $("#EmployeeModalContent").html(response);

            $('#EmployeeForm').data('validator', null);
            $.validator.unobtrusive.parse('#EmployeeForm');

            $("#EmployeeModal").modal("show");
        },
        error: function () {
            CloseLoading();
        }
    });
}

function EmployeeFormSubmited(response) {
    CloseLoading();
    if (response.status === "Success") {
        swal("انجام شد", "عملیات با موفقیت انجام شد", "success");
        $("#EmployeeModal").modal("hide");
        $("#EmployeeDiv").load(location.href + " #EmployeeDiv");
    } else {
        swal("خطا", "عملیات با خطا مواجه شده است . لطفا مجددا تلاش نمائید  ", "error");
    }
}


function DeleteEmployee(employeeId) {
    swal({
        title: "مطمئنید  ?",
        text: "اگر حذف کنید دیگر به این کارمند دسترسی ندارید !",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/delete-employee",
                    type: "get",
                    data: {
                        employeeId: employeeId
                    },
                    beforeSend: function () {
                        StartLoading();
                    },
                    success: function (response) {
                        CloseLoading();
                        if (response.status === "Success") {
                            swal("انجام شد", "عملیات با موفقیت انجام شد", "success");
                            $(`#Employee-${employeeId}`).remove();
                        } else {
                            swal("خطا", "  عملیات با خطا مواجه شده است. لطفا مجددا تلاش نمائید ... ", "error");
                        }
                    },
                    error: function () {
                        CloseLoading();
                    }
                });
            }
        });
}


