import PlateLayout from '~/plate/layout/PlateLayout';
import PlateLayoutForm from '~/plate/layout/PlateLayoutForm';
import ClientFormView from '../views/ClientFormView';

export default function ClientCreatePage() {
  return (
    <PlateLayout>
      <PlateLayoutForm title={'Create Client'}>
        <ClientFormView />
      </PlateLayoutForm>
    </PlateLayout>
  );
}
