import { Cropper } from 'react-cropper'
import 'cropperjs/dist/cropper.css'

interface Props {
    setCropper: (cropper: Cropper) => void;
    imagePreview: string;
}

export default function PhotoWidgetCropper({ setCropper, imagePreview }: Props) {
  return (
    <Cropper
        style={{ height: 200, width: '100%' }}
        preview='.img-preview'
        guides={false}
        src={imagePreview}
        initialAspectRatio={1}
        aspectRatio={1}
        viewMode={1}
        // dragMode='move'
        autoCropArea={1}
        background={false}
        //scalable={true}
        // cropBoxMovable={true}
        // cropBoxResizable={true} 
        onInitialized={cropper => setCropper(cropper)}
    
    />
  )
}
