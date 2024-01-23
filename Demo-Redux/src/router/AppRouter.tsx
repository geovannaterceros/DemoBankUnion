import { useSelector } from 'react-redux';
import { Navigate, Route, Routes } from 'react-router-dom';
import AuthRoutes from '~/auth/router/AuthRoutes';
import ClientRoutes from '~/client/router/AppRouter';
import { useCheckAuth } from '~/hooks/useCheckAuth';
import PlateRoutes from '~/plate/router/PlateRoutes';
import { CheckingAuth } from '~/ui/CheckingAuth';

export default function AppRouter() {
  const { status } = useSelector((state: any) => state.auth);
  console.log(status);
  useCheckAuth();

  if (status === 'checking') {
    return <CheckingAuth />;
  }

  return (
    <Routes>
      {/* {status === 'authenticated' ? (
        <>
          <Route path='/*' element={<PlateRoutes />} />
          <Route path='/plate/*' element={<PlateRoutes />} />
        </>
      ) : (
        <Route path='/auth/*' element={<AuthRoutes />} />
      )}

      <Route path='/*' element={<Navigate to='/auth/login' />} /> */}
      <Route path='/*' element={<ClientRoutes />} />
      <Route path='/client/*' element={<ClientRoutes />} />
    </Routes>
  );
}
