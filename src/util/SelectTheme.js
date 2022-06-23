export const selectDarkTheme = (theme) => {
    const darkTheme = {
        ...theme,
        borderRadius: 0,
        colors: {
            ...theme.colors,
            neutral0: '#222',
            neutral5: '#333',
            neutral10: '#444',
            neutral20: '#666',
            neutral30: '#888',
            neutral40: '#999',
            neutral50: '#aaa',
            neutral60: '#bbb',
            neutral70: '#ccc',
            neutral80: '#ddd',
            neutral90: '#eee',

            primary: '#444',
            primary25: '#333',
            primary50: '#444',
            primary75: '#555',

            danger: '#ffb3ab',
            dangerLight: '#601a13'
        },
    }

    return darkTheme;

}

export const selectLightTheme = (theme) => {
    return theme
}