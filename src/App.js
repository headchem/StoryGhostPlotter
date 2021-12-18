import React, { useState, useEffect } from 'react';

function App() {
  const [data, setData] = useState('');

  useEffect(() => {
    (async function () {
      const text = await( await fetch(`/api/MyWebservice`)).text();//.json();
      //const text = 'testing123';
      console.log('text was: ' + text);
      console.log('React version: ' + React.version);
      setData('React version: ' + React.version + 'testing...' + text);
    })();
  });

  return <div>{data}</div>;
}

export default App;