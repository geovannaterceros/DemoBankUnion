import { Button, Grid, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';
//import { useSelector } from 'react-redux';
// import { useDispatch } from 'react-redux';
// import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
// import { RootState } from '~/store';
//import { useEffect } from 'react';
//import { ThunkGetPlate } from '~/store/plate/thunks';
import ClientTableView from '../views/ClientTableView';
import ClientLayout from '../layout/ClientLayout';
export default function PlatePage() {
  // const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const navigate = useNavigate();

  const handleCreate = () => {
    navigate('/client/create');
  };

  //   useEffect(() => {
  //     dispatch(ThunkGetPlate());
  //   }, [dispatch]);

  return (
    <ClientLayout>
      <Grid container direction='column' sx={{ mb: 1 }} spacing={4}>
        <Grid item>
          <Typography variant='h4' align='center'>
            Clients
          </Typography>
        </Grid>
        <Grid item>
          <Button variant='contained' sx={{ textAlign: 'left' }} onClick={handleCreate}>
            {' '}
            Add Client{' '}
          </Button>
        </Grid>
        <Grid item>
          <ClientTableView />
        </Grid>
      </Grid>
    </ClientLayout>
  );
}
