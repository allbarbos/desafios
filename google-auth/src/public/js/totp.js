TOTP = function() {
    var dec2hex = function(s) {
        return (s < 15.5 ? "0" : "") + Math.round(s).toString(16);
    };

    var hex2dec = function(s) {
        return parseInt(s, 16);
    };

    var leftpad = function (str, len, pad) {
        if (len + 1 >= str.length) {
            str = Array(len + 1 - str.length).join(pad) + str;
        }
        return str;
    };

    var base32tohex = function (base32) {
        var val;
        var base32chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        var bits = "";
        var i = 0;

        while (i < base32.length) {
            val = base32chars.indexOf(base32.charAt(i).toUpperCase());
            bits += leftpad(val.toString(2), 5, "0");
            i++;
        }

        var chunk;
        var hex = "";
        i = 0;

        while (i + 4 <= bits.length) {
            chunk = bits.substr(i, 4);
            hex = hex + parseInt(chunk, 2).toString(16);
            i += 4;
        }

        return hex;
    };

    this.getOTP = function(secret) {
        try {
            var now = new Date().getTime();
            var expiry = 30;
            var length = 6;
            var key = base32tohex(secret);
            var epoch = Math.round(now / 1000.0);
            var time = leftpad(dec2hex(Math.floor(epoch / expiry)), 16, "0");
            var shaObj = new jsSHA("SHA-1", "HEX");
            shaObj.setHMACKey(key, "HEX");
            shaObj.update(time);
            
            var hmac = shaObj.getHMAC("HEX");
            var offset;
            // hmacObj = new jsSHA(time, "HEX")  # Dependency on sha.js
            // hmac = hmacObj.getHMAC(key, "HEX", "SHA-1", "HEX")
            if (hmac === "KEY MUST BE IN BYTE INCREMENTS") {
                throw "Error: hex key must be in byte increments";
            } else {
                // return null
                offset = hex2dec(hmac.substring(hmac.length - 1));
            }
            
            var otp = (hex2dec(hmac.substr(offset * 2, 8)) & hex2dec("7fffffff")) + "";

            if (otp.length > length) {
                otp = otp.substr(otp.length - length, length);
            } else {
                otp = leftpad(otp, length, "0");
            }
        } catch (error) {
            throw error;
        }
        return otp;
    };

    this.validate = function(userCode) {
        var _code = this.getOTP("ONSW443FMRUWC")

        return _code == userCode;
    }
}