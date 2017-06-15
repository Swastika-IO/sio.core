var SW = window.SW || {};

(function ($) {
    SW.Common = {
        edtModule: '',
        getPagingTable: function (obj) {
            var items = obj['items'];
            var row = document.createElement("div");
            row.className = 'row';
            var table = document.createElement("Table");
            table.className = 'table table-bordered table-striped table-sm';
            var thead = document.createElement('thead');
            if (items.length > 0) {
                var paging = document.createElement("paging");
                paging.className = 'pagination';
                var fstObj = items[0];
                for (var name in fstObj) {
                    var th = document.createElement('th');
                    th.innerHTML = name;
                    thead.appendChild(th);
                }
                table.appendChild(thead);
                items.forEach(function (item) {

                    var trContent = document.createElement('tr');
                    for (var name in item) {

                        var tdContent = document.createElement('td');
                        tdContent.innerHTML = item[name];
                        trContent.appendChild(tdContent);
                    }
                    table.appendChild(trContent);
                });

                $(paging).pagination({
                    items: obj.totalItems,
                    itemsOnPage: obj.pageSize,
                    currentPage: obj.pageIndex + 1
                });
                row.appendChild(table);
                row.appendChild(paging);                
            }
            return row;
        },
        getBase64: function (file) {
            var reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                return reader.result;
            };
            reader.onerror = function (error) {
                
            };
            return null;
        },       
        executeFunctionByName: function (functionName, args, context) {
            if (functionName != null) {
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
                if (pair[0] == variable) {
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
    }
}(jQuery));