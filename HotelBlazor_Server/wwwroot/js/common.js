window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'TOASTR SUCCESS MESSAGE!!!');
    } else if
    (type === "error") {
        toastr.error(message, "ERROR MESSAGE FROM TOASTR!!!");
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire({
            title: "Success",
            text: "Success!",
            icon: "success",
            confirmButtonText: "Ok, I guess"
        });
    } else if (type === "error") {
        Swal.fire({
            title: "Error",
            text: "Error has been logged!",
            icon: "error",
            confirmButtonText: "Ok, I guess"
        });
    }
}