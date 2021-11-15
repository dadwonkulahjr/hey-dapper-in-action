﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#companies').DataTable({
        'ajax': {
            'url': '/api/companies',
            'type': 'GET',
            'dataType': 'json'
        },
        'columns': [
            { 'data': 'name'},
            { 'data': 'address' },
            { 'data': 'city' },
            { 'data': 'state' },
            { 'data': 'postCode' },
            {
                'data': 'id',
                'render': function (data) {
                    return `<div class="text-center">
                            <a href="/company/upsert?id=${data}" class="btn btn-success text-white"
                            style="cursor:pointer;width:100px;">
                             <i class="far fa-edit"></i>Edit
                            </a>
                            <a class="btn btn-danger text-white"
                            style="cursor:pointer;width:100px;" onclick=Delete('/api/companies/'+${data})>
                             <i class="far fa-trash-alt"></i>Delete
                            </a>
                            `;
                }, 'width': '30%'
            }
        ],
        'language': {
            'emptyTable': 'No data has been added yet!'
        },
        'width': '100%'
    });

}

function Delete(url) {
    swal({
        title: 'Are you sure you want to Delete?',
        text: 'You will not be able to restored the data!',
        icon: 'warning',
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }

            });
        }
    });
}
