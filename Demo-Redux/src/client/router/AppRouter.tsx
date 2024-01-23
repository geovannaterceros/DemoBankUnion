import { Route, Routes } from 'react-router-dom';
//import PlateCreatePage from '../pages/PlateCreatePage';
//import PlateUpdatePage from '../pages/PlateUpdatePage';
import ClientPage from '../pages/ClientPage';
import ClientCreatePage from '../pages/ClientCreatePate';

export default function ClientRoutes() {
  return (
    <Routes>
      <Route path='/' element={<ClientPage />} />
      <Route path='/create' element={<ClientCreatePage />} />
      {/* <Route path='/update/:id' element={<PlateUpdatePage />} />  */}
    </Routes>
  );
}
