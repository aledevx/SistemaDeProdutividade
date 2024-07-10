window.blazorExtensions = {
    writeCookie: function (name, value, expires) {
        let expiresString = "";
        if (expires) {
            expiresString = "; expires=" + new Date(expires).toUTCString();
        }
        document.cookie = name + "=" + encodeURIComponent(value) + expiresString + "; path=/";
    },
    deleteCookie: function (name) {
        document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
    },
    navigateBack: function () {
        window.history.back();
    }
};