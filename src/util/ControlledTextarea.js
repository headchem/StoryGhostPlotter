// FROM: https://stackoverflow.com/questions/46000544/react-controlled-input-cursor-jumps
// fixes the behavior where a controlled textarea (where you set value instead of defaultValue) would always jump the cursor to end preventing you from making edits in the middle of the text
import React, { useEffect, useRef, useState } from 'react';

const ControlledTextArea = (props) => {
   const { value, onChange, ...rest } = props;
   const [cursor, setCursor] = useState(null);
   const ref = useRef(null);

   useEffect(() => {
      const input = ref.current;
      if (input) input.setSelectionRange(cursor, cursor);
   }, [ref, cursor, value]);

   const handleChange = (e) => {
      setCursor(e.target.selectionStart);
      onChange && onChange(e);
   };

   return <textarea ref={ref} value={value} onChange={handleChange} {...rest} />;
};

export default ControlledTextArea;