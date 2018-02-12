var SW = window.SW || {};

(function ($) {
    SW.Common = {
        templateEditor: null,
        edtModule: '',
        loadFiles: async function (container) {
            $.ajax({
                url: '/api/files',
                type: "GET",
                success: function (result) {
                    //container.dataTable().fnDestroy();
                    container.find('tbody').empty();
                    $.each(result, function (index, val) {
                        var html = '<tr>';
                        html += '<td>' + val.fileFolder + '</td>';
                        html += '<td>' + val.filename + '</td>';
                        if (val.fileFolder === 'Images') {
                            html += '<td><img width="100px" src="' + val.fullPath + '"/></td>';
                        }
                        else {
                            html += '<td>' + val.filename + '</td>';
                        }
                        html += '<td><input onClick="this.select();" class="form-control" value="' + location.origin + val.fullPath + '"/></td>';
                        html += '</tr>';
                        container.find('tbody').append(html);
                    });

                    //container.DataTable({
                    //    "paging": true,
                    //    "pageLength": 5,
                    //    "lengthChange": false,
                    //    "select": true,
                    //    "searching": false,
                    //    "ordering": true,
                    //    "info": false,
                    //    "autoWidth": true//,
                    //    //"rowReorder": true
                    //});
                },
                error: function (err) {
                    return null;
                }
            });
        },
        loadFileStream: async function (folder) {
            var img = document.querySelector('#file').files[0];

            if (img !== null) {
                var name = img.name.split('.')[0];
                var ext = img.name.split('.')[1];

                var reader = new FileReader();
                reader.readAsDataURL(img);
                reader.onload = function () {
                    //var index = reader.result.indexOf(',') + 1;
                    var base64 = reader.result; //.substring(index);
                    var obj = {
                        fileFolder: folder,
                        filename: name,
                        extension: ext,
                        fileStream: base64
                    };
                    $.ajax({
                        url: '/api/file/uploadFile',
                        type: "POST",
                        data: obj,
                        success: function (result) {
                            var container = $("#modal-files").find('table');
                            SW.Common.loadFiles(container);
                        },
                        error: function (err) {
                            return '';
                        }
                    });
                    console.log(obj);
                };
                reader.onerror = function (error) {
                };
            }
        },
        init: async function () {
            $("#modal-files").on('show.bs.modal', function () {
                var container = $("#modal-files").find('table');
                SW.Common.loadFiles(container);
            });

            $('[data-toggle="popover"]').popover();

            $(".sortable").sortable({
                revert: true,
                update: function (event, ui) {
                    //create the array that hold the positions...
                    var order = [];
                    //loop trought each li...
                    $('.sortable .sortable-item').each(function (i, e) {
                        //add each li position to the array...
                        // the +1 is for make it start from 1 instead of 0
                        //order.push($(this).attr('id') + '=' + ($(this).index() + 1));
                        $(e).find('.item-priority').val($(e).index() + 1);
                        //alert($(this).attr('module-priority'));

                        var model = $(e).attr('sort-model');
                        var modelId = $(e).attr('sort-model-id');
                        if (model !== undefined && modelId !== undefined) {
                            var data = [{
                                "propertyName": "Priority",
                                "propertyValue": $(e).index() + 1
                            }];
                            var settings = {
                                "async": true,
                                "crossDomain": true,
                                "url": "/api/vi-vn/" + model + "/save/" + modelId,
                                "method": "POST",
                                "headers": {
                                    "Content-Type": "application/json"
                                },
                                "processData": false,
                                "data": JSON.stringify(data)
                            }

                            $.ajax(settings).done(function (response) {
                                console.log(response);
                            });
                        }
                    });

                    // join the array as single variable...
                    var positions = order.join(';')
                    //use the variable as you need!
                    //alert(positions);
                    // $.cookie( LI_POSITION , positions , { expires: 10 });
                }
            });

            $(document).on('change', '.custom-file .custom-file-input', function () {
                var file = this.files[0];
                if (file !== undefined && file !== null) {
                    var container = $(this).parent('.custom-file');
                    //SW.Common.getBase64(file, $('.custom-file')).then(result => console.log(result));
                    //await SW.Common.getBase64(file).then(result => console.log(result));
                    var fileName = SW.Common.uploadImage(file, container);
                }
            });

            // not work with BS 4 (using now http://bootstrap-tagsinput.github.io/bootstrap-tagsinput/examples/)
            //$(".tags")
            //    .on('tokenfield:createdtoken', function (e) {
            //        //$('.tags').val($('.tags').tokenfield('getTokensList'));
            //    })

            //    .on('tokenfield:edittoken', function (e) {
            //    })

            //    .on('tokenfield:removedtoken', function (e) {
            //        //$('.tags').val($('.tags').tokenfield('getTokensList'));
            //    }).tokenfield();

            //Enable iCheck plugin for checkboxes
            //iCheck for checkbox and radio inputs
            //$('input[type="checkbox"]').iCheck({
            //    checkboxClass: 'icheckbox_square-blue',
            //    radioClass: 'iradio_square-blue'
            //});
            $("input[type='checkbox']").on('ifChanged', function (e) {
                $(this).val(e.target.checked === true);
            });

            //$(".select2").select2();

            //$('.dataTable').DataTable({
            //    "paging": false,
            //    "lengthChange": false,
            //    //"select": true,
            //    "searching": false,
            //    "ordering": true,
            //    "info": false,
            //    "autoWidth": true//,
            //    //"rowReorder": true
            //});
            //$('.dataTable tr').on('click', function () {
            //    $(this).toggleClass('selected');
            //})

            $('.custom-file .custom-file-val').on('change', function () {
                $(this).parent('.custom-file').find('img').attr('src', $(this).val());
            });
            $('.editor-content').trumbowyg()
            // Init Code editor
            $.each($('.code-editor'), function (i, e) {
                var container = $(this);
                var editor = ace.edit(e);
                if (container.hasClass('json')) {
                    editor.session.setMode("ace/mode/json");
                }
                else {
                    editor.session.setMode("ace/mode/razor");
                }
                editor.setTheme("ace/theme/chrome");
                //editor.setReadOnly(true);

                editor.session.setUseWrapMode(true);
                editor.setOptions({
                    maxLines: Infinity
                });
                editor.getSession().on('change', function (e) {
                    // e.type, etc
                    $(container).parent().find('.code-content').val(editor.getValue());
                });
            })
            if ($('#code-editor').length > 0) {
                SW.Common.templateEditor = ace.edit("code-editor");
                SW.Common.templateEditor.setTheme("ace/theme/chrome");
                SW.Common.templateEditor.session.setMode("ace/mode/razor");
                SW.Common.templateEditor.session.setUseWrapMode(true);
                SW.Common.templateEditor.setOptions({
                    maxLines: Infinity
                });
                SW.Common.templateEditor.getSession().on('change', function (e) {
                    // e.type, etc
                    $('#code-editor').parent().find('.code-content').val(SW.Common.templateEditor.getValue());
                });
            }
            $('#sel-template').on('change', function () {
                SW.Common.templateEditor.setValue($(this).val());
                var templateName = $(this).find('option:selected').text();
                if (templateName === "[ NEW TEMPLATE ]") {
                    $('.sel-filename').attr('value', ''); // use attr instead of val to fix bug value not change https://stackoverflow.com/questions/11873721/jquery-val-change-doesnt-change-input-value
                } else {
                    $('.sel-filename').attr('value', templateName);
                }
            });
            $('.sel-filename').on('change', function () {
                $('.sel-filename').attr('value', $(this).val());
            });

            var selVal = $('.selectpicker').data('val');
            // TODO: ERROR with bootstrap 4
            //$('.selectpicker').selectpicker('val', selVal);

            // TODO: ERROR with bootstrap 4
            //$('[data-toggle=confirmation]').confirmation({
            //    rootSelector: '[data-toggle=confirmation]',
            //    container: 'body'
            //});
        },
        //folder : 'Modules/Banners'
        uploadImage: function (file, container) {
            // Create FormData object
            var files = new FormData();
            var folder = container.find('.folder-val').val();
            // Looping over all files and add it to FormData object
            files.append(file.name, file);

            // Adding one more key to FormData object
            files.append('fileFolder', folder);

            $.ajax({
                url: '/api/vi-vn/media/upload', //'/api/tts/UploadImage',
                type: "POST",
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                data: files,
                success: function (result) {
                    container.find('.custom-file-val').val(result);
                    container.find('.custom-file-img').attr('src', result);
                    return result;
                },
                error: function (err) {
                    return '';
                }
            });
        },
        showError: function (error) {
            console.log(error);
            $('#modal-error .modal-body').html('Error messages');
            $('#modal-error').modal('show');
        },
        ajaxSubmitForm: function (form, url) {
            var frm = new FormData();
            frm.append('ModuleData', form.serialize());
            $.ajax({
                url: url,
                type: 'POST',
                processData: true, // Not to process data
                data: form.serialize(),
                success: function (data) {
                    console.log('Submission was successful.');
                    console.log(data);
                },
                error: function (data) {
                    console.log('An error occurred.');
                    console.log(data);
                },
            });
        },
        getApiResult: async function (req) {
            //req.Authorization = authService.authentication.token;
            var headers = {
                'Content-Type': 'application/json'
                //'RefreshToken': authService.authentication.refresh_token
            };
            req.headers = headers;
            return $.ajax(req).done(function (results) {
                if (results.data.responseKey === 'NotAuthorized') {
                    //Try again with new token from previous Request (optional)
                    setTimeout(function () {
                        headers = {
                            'Content-Type': 'application/json',
                            'RefreshToken': authService.authentication.refresh_token
                        };
                        req.headers = headers;
                        return $.ajax(req).done(function (results) {
                            //if (results.data.responseKey === 'NotAuthorized') {
                            //    authService.logOut();
                            //    $location.path('/admin/login');
                            //}
                            //else {
                            //    return results;
                            //}
                        });
                    }, 2000);
                }
                //else if (results.data.authData !== null && results.data.authData !== undefined) {
                //    var authData = results.data.authData;
                //    //localStorageService.set('authorizationData', { token: authData.access_token, userName: authData.userData.NickName, roleNames: authData.userData.RoleNames, avatar: authData.userData.Avatar, refresh_token: authData.refresh_token, userId: authData.userData.Id });
                //    //authService.authentication.isAuth = true;
                //    //authService.authentication.isAdmin = $.inArray("Admin", authData.userData.RoleNames) >= 0;
                //    //authService.authentication.userName = authData.userData.NickName;
                //    //authService.authentication.roleNames = authData.userData.RoleNames;
                //    //authService.authentication.userId = authData.userData.Id;
                //    //authService.authentication.avatar = authData.userData.Avatar;
                //    //authService.authentication.token = authData.access_token;
                //    //authService.authentication.refresh_token = authData.refresh_token;
                //}
                return results;
            },
                function () {
                });
        },
        getPagingTable: function (obj, title, headers) {
            /// Example: var table = SW.Common.getPagingTable(obj, 'Header Title', ['Col 1', null, 'Col 2', 'Col 3', null, 'Col 4']);

            var items = obj['items'];
            title = title !== undefined ? title : '';

            var card = this.createElement('div', 'card');
            var icon = this.createElement('i', 'fa fa-align-justify');
            var cardHeader = this.createElement('div', 'card-header');
            cardHeader.innerHTML = title;
            $(cardHeader).prepend(icon);
            card.appendChild(cardHeader);

            var cardBlock = this.createElement('div', 'card-block');

            var table = document.createElement("Table");
            table.className = 'table table-bordered table-striped';

            // Create table headers
            var thead = document.createElement('thead');
            if (headers === undefined) {
                headers = [];
                var fstObj = items[0];
                for (var name in fstObj) {
                    headers.push(name.toString());
                    console.log(name);
                }
            }
            headers.forEach(function (header) {
                if (header !== null) {
                    var th = document.createElement('th');
                    th.innerHTML = header.display;
                    thead.appendChild(th);
                }
            });
            table.appendChild(thead);

            if (items.length > 0) {
                var paging = document.createElement("paging");
                paging.className = 'pagination';

                items.forEach(function (item) {
                    var trContent = document.createElement('tr');
                    var i = 0;
                    headers.forEach(function (header) {
                        //if (trContent.childNodes.length < headers.length && headers[i] != null) {
                        var tdContent = document.createElement('td');
                        tdContent.innerHTML = '<span>' + item[header.key] + '</span>';
                        trContent.appendChild(tdContent);
                        //}
                        i++;
                    });
                    table.appendChild(trContent);
                });

                //$(paging).pagination({
                //    items: obj.totalItems,
                //    itemsOnPage: obj.pageSize,
                //    currentPage: obj.pageIndex + 1
                //});
                //$(paging).find('li').addClass('page-item')
                cardBlock.appendChild(table);
                cardBlock.appendChild(paging);
                card.appendChild(cardBlock);
            }
            return card;
        },
        createElement: function (eName, eClass) {
            var el = document.createElement(eName);
            el.className = eClass;
            return el;
        },
        getBase64: async function (file, container) {
            if (file !== null) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function () {
                    var index = reader.result.indexOf(',') + 1;
                    var base64 = reader.result.substring(index);
                    container.find('.custom-file-val').val(reader.result);
                    container.find('.custom-file-img').attr('src', reader.result);
                    return base64;
                };
                reader.onerror = function (error) {
                    console.log(error);
                };
            }
            else {
                return null;
            }
        },
        executeFunctionByName: function (functionName, args, context) {
            if (functionName !== null) {
                var namespaces = functionName.split(".");
                var func = namespaces.pop();
                for (var i = 0; i < namespaces.length; i++) {
                    context = context[namespaces[i]];
                }
                return context[func].apply(this, args);
            }
        },
        delayExecuteFunction: function (time, callbackFunctionName, params) {
            var timer = setInterval(function () {
                CEPT.Global.executeFunctionByName(callbackFunctionName, window, params);
                clearInterval(timer);
            }, time);
        },
        prettyJsonObj: function (obj) {
            return JSON.stringify(obj, null, '\t');
        },
        // Route operations

        writeEvent: function (line) {
            var messages = $("#Messages");
            messages.prepend("<li style='color:blue;'>" + TTX.Common.getTimeString() + ' ' + line + "</li>");
        },

        writeError: function (line) {
            var messages = $("#Messages");
            messages.prepend("<li style='color:red;'>" + TTX.Common.getTimeString() + ' ' + line + "</li>");
        },

        writeLine: function (line) {
            var messages = $("#Messages");
            messages.prepend("<li style='color:black;'>" + TTX.Common.getTimeString() + ' ' + line + "</li>");
        },

        printState: function (state) {
            var messages = $("#Messages");
            return ["connecting", "connected", "reconnecting", state, "disconnected"][state];
        },

        getTimeString: function () {
            var currentTime = new Date();
            return currentTime.toTimeString();
        },

        getQueryVariable: function (variable) {
            var query = window.location.search.substring(1),
                vars = query.split("&"),
                pair;
            for (var i = 0; i < vars.length; i++) {
                pair = vars[i].split("=");
                if (pair[0] === variable) {
                    return unescape(pair[1]);
                }
            }
        },

        getSecurityHeaders: function () {
            var accessToken = sessionStorage["accessToken"] || localStorage["accessToken"];

            if (accessToken) {
                return { "Authorization": "Bearer " + accessToken };
            }

            return {};
        },

        // Operations
        clearAccessToken: function () {
            localStorage.removeItem("accessToken");
            sessionStorage.removeItem("accessToken");
            sessionStorage.removeItem("currentUser");
        },

        setAccessToken: function (accessToken, persistent) {
            if (persistent) {
                localStorage["accessToken"] = accessToken;
            } else {
                sessionStorage["accessToken"] = accessToken;
            }
        },
        setCurrentUser: function (user) {
            sessionStorage["currentUser"] = JSON.stringify(user);
        },
        getCurrentUser: function () {
            var currentUser = sessionStorage["currentUser"];
            if (currentUser) {
                return $.parseJSON(currentUser);
            }
        },

        toErrorsArray: function (data) {
            var errors = new Array(),
                items;

            if (!data || !data.message) {
                return null;
            }

            if (data.modelState) {
                for (var key in data.modelState) {
                    items = data.modelState[key];

                    if (items.length) {
                        for (var i = 0; i < items.length; i++) {
                            errors.push(items[i]);
                        }
                    }
                }
            }

            if (errors.length === 0) {
                errors.push(data.message);
            }

            return errors;
        },

        // Data
        //self.returnUrl = siteUrl;

        htmlEncode: function (value) {
            var encodedValue = $('<div />').text(value).html();
            return encodedValue;
        }
    };
    $(document).ready(function () {
        SW.Common.init();
    })
}(jQuery));