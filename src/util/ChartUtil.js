// FROM: https://observablehq.com/@mbostock/turbo
// Google's Turbo color palette (https://ai.googleblog.com/2019/08/turbo-improved-rainbow-colormap-for.html)
export const interpolateTurbo = (x) => {
    x = Math.max(0, Math.min(1, x));
    return `rgb(${[
        34.61 + x * (1172.33 - x * (10793.56 - x * (33300.12 - x * (38394.49 - x * 14825.05)))),
        23.31 + x * (557.33 + x * (1225.33 - x * (3574.96 - x * (1073.77 + x * 707.56)))),
        27.2 + x * (3211.1 - x * (15327.97 - x * (27814 - x * (22569.18 - x * 6838.66))))
    ].map(Math.floor).join(", ")})`;
}