import ReactDOM from 'react-dom/client';

import { Provider } from 'react-redux';
import { store } from './store';
import { BrowserRouter } from 'react-router-dom';
import AppPlate from './AppPlate';
import AppClient from './AppClient';

ReactDOM.createRoot(document.getElementById('root')!).render(
  // <React.StrictMode>
  <BrowserRouter>
    <Provider store={store}>
      <AppClient />
    </Provider>
  </BrowserRouter>,

  // </React.StrictMode>,
);
