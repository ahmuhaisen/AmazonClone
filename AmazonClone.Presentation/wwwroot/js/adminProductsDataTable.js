$(document).ready(function () {
    var table = $('#productsDataTable').DataTable({
        "serverSide": false,
        "filter": true,
        "ajax": {
            "url": "/Admin/Product/IndexDataTable",
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                var searchDefValue = json.searchDefValue;
                table.search(searchDefValue).draw();
                return json.data.$values;
            }
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ],
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            {
                "data": "imageUrl", "name": 'ImageUrl', "width": "1%", "orderable": false,
                "render": function (data, type, row) {
                    return "<img src='/.." + row.imageUrl + "' class='rounded' width='55px' height='55px'/>"
                }
            },
            {
                "data": "name", "name": "Name", "width": "50%",
                "render": function (data, type, row) {
                    return `<a href="/Admin/Product/Details/${row.id}" class="normal-link">${row.name}</a>`
                }
            },
            {
                "data": "category.name", "name": "Category.Name", "autowidth": true,
                "render": function (data, type, row) {
                    return `<span class="badge bg-warning">${row.category.name}</span>`
                }
            },
            {
                "data": "price", "name": "Price", "searchable": false,
                "render": function (data, type, row) {
                    return `<span>$${row.price}</span>`
                }
            },
            {
                "data": "id", "orderable": false,
                "render": function (data, type, row) {
                    return `<div class="btn-group" role="group">
                            <a href="/Admin/Product/Upsert/${row.id}" class="btn btn-dark">Edit</a>
                            <a onclick="DeleteProduct('/Admin/Product/Delete/${row.id}')" class="btn btn-danger">Delete</a>
                        </div>`;
                },
            }
        ]
    });
});
