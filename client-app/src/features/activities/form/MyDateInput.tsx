// import { useField } from "formik";
// import { Form, Label } from "semantic-ui-react";
// import DatePicker, {DatePickerProps} from "react-datepicker";


// export default function MyDateInput(props: Partial<DatePickerProps>) {
//     const [field, meta, helpers] = useField(props.name!);
//   return (
//     <Form.Field error={meta.touched && !!meta.error}>
//         <DatePicker 
//         {...field}
//         // {...props}
        
//         selected={(field.value && new Date(field.value)) || null}
//         onChange={value => helpers.setValue(value)}
//         />
//         {meta.touched && meta.error ? (
//             <Label basic color="red">{meta.error}</Label>
//         ) : null}
//     </Form.Field>
//   )
//}
//  


import { useField } from "formik";
import { Form, Label } from "semantic-ui-react";
import DatePicker from "react-datepicker";
// import "react-datepicker/dist/react-datepicker.css";

interface MyDateInputProps {
  name: string;
  placeholderText?: string;
  showTimeSelect?: boolean;
  dateFormat?: string;
}

export default function MyDateInput({
  name,
  placeholderText,
  showTimeSelect = false,
  dateFormat = "MMMM d, yyyy h:mm aa",
}: MyDateInputProps) {
  const [field, meta, helpers] = useField(name);

  return (
    <Form.Field error={meta.touched && !!meta.error}>
      <DatePicker
        selected={(field.value && new Date(field.value)) || null}
        onChange={(value) => helpers.setValue(value)}
        placeholderText={placeholderText}
        showTimeSelect={showTimeSelect}
        dateFormat={dateFormat}
      />
      {meta.touched && meta.error ? (
        <Label basic color="red">
          {meta.error}
        </Label>
      ) : null}
    </Form.Field>
  );
}
// export default function MyDateInput(props: Partial<DatePickerProps>) {
//     const [field, meta, helpers] = useField(props.name!);
//   return (
//     <Form.Field error={meta.touched && !!meta.error}>
//         <DatePicker 
//         {...field}
//         // {...props}
        
//         selected={(field.value && new Date(field.value)) || null}
//         onChange={value => helpers.setValue(value)}
//         />
//         {meta.touched && meta.error ? (
//             <Label basic color="red">{meta.error}</Label>
//         ) : null}
//     </Form.Field>
//   )
//}
//  