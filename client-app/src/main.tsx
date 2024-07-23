import React from 'react'
import ReactDOM from 'react-dom/client'
import 'react-calendar/dist/Calendar.css'
import 'semantic-ui-css/semantic.min.css'
import 'react-toastify/dist/ReactToastify.min.css'
import './app/layout/styles.css'
import 'react-datepicker/dist/react-datepicker.css'
import { StoreContext } from './app/stores/store.ts'
import { store } from './app/stores/store.ts'
import { RouterProvider } from 'react-router-dom'
import { router } from './router/Routes.tsx'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <StoreContext.Provider value={store}>
    <RouterProvider router={router}/>
    </StoreContext.Provider>
  </React.StrictMode>,
)
