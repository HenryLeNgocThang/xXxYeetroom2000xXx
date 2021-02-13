
module.exports = {
    brightness: function(r, g, b, dark = "dark", light = "light") {
        var brightness = Math.round(((parseInt(r) * 299) +
            (parseInt(g) * 587) +
            (parseInt(b) * 114)) / 1000);
        var color = (brightness > 125) ? dark : light;

        return color;
    },
    hexToRgb: function(hex) {
        var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
        return result ? {
            r: parseInt(result[1], 16),
            g: parseInt(result[2], 16),
            b: parseInt(result[3], 16)
        } : null;
    }
}