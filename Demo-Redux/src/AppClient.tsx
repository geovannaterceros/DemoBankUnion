import AppRouter from './router/AppRouter';
import AppTheme from './theme/AppTheme';

export default function AppClient() {
  return (
    <AppTheme>
      <AppRouter />
    </AppTheme>
  );
}
