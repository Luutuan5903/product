(function ($) {
    var _productService = abp.services.app.product,
        l = abp.localization.getSource('FinallyProject'),
        _$modal = $('#ProductCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ProductsTable');

    var _$productsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _productService.getAll,
            inputFilter: function () {
                return $('#ProductsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$productsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                data: 'name',
                sortable: true
            },
            {
                targets: 1,
                data: 'price',
                sortable: true,
                render: data => `${data.toLocaleString()} đ`
            },
            {
                targets: 2,
                data: 'image',
                sortable: false,
                render: data => `<img src="${data}" width="50" height="50" />`
            },
            {
                targets: 3,
                data: 'category',
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                render: (data, type, row) => {
                    return [
                        `<button type="button" class="btn btn-sm bg-secondary edit-product" data-product-id="${row.id}" data-toggle="modal" data-target="#ProductEditModal">`,
                        `   <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        `</button>`,
                        `<button type="button" class="btn btn-sm bg-danger delete-product" data-product-id="${row.id}" data-product-name="${row.name}">`,
                        `   <i class="fas fa-trash"></i> ${l('Delete')}`,
                        `</button>`
                    ].join(' ');
                }
            }
        ]
    });

    _$form.validate({
        rules: {
            Name: "required",
            Price: {
                required: true,
                number: true
            }
        }
    });

    _$form.find('.save-button').on('click', function (e) {
        e.preventDefault();
        if (!_$form.valid()) return;

        var product = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _productService.create(product).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$productsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-product', function () {
        var productId = $(this).attr("data-product-id");
        var productName = $(this).attr("data-product-name");

        abp.message.confirm(
            abp.utils.formatString(l('Bạn có muốn xoá {0}?'), productName),
            null,
            function (isConfirmed) {
                if (isConfirmed) {
                    _productService.delete(productId).done(function () {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$productsTable.ajax.reload();
                    });
                }
            }
        );
    });

    $(document).on('click', '.edit-product', function (e) {
        var productId = $(this).attr("data-product-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Products/EditModal?productId=' + productId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductEditModal .modal-content').html(content);
            }
        });
    });

    abp.event.on('product.edited', function () {
        _$productsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', function () {
        _$productsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', function (e) {
        if (e.which === 13) {
            _$productsTable.ajax.reload();
            return false;
        }
    });

})(jQuery);
