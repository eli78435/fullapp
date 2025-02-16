import React, { useState, useEffect, useMemo } from 'react';
import { fetchUsers } from '../../services/userService';
import styles from './UserList.module.css';
import type { MRT_ColumnDef } from 'material-react-table';
import { MaterialReactTable, useMaterialReactTable } from 'material-react-table';
import { User } from '../../models/User';

interface UserRow {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
};

const UsersList: React.FC = () => {
    const columns = useMemo<MRT_ColumnDef<UserRow>[]>(
        () => [
            {
                header: 'Id',
                accessorKey: 'id',
            },
            {
                header: 'First Name',
                accessorKey: 'firstName',
            },
            {
                header: 'Last Name',
                accessorKey: 'lastName',
            },
            {
                header: 'Email',
                accessorKey: 'email',
            },
            {
                header: 'Role',
                accessorKey: 'role',
            },
        ],
        [],
    );

    const [users, setUsers] = useState<UserRow[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const getUsers = async () => {
            try {
                const data = await fetchUsers();
                const usersData: UserRow[] = data.map((u: User) => ({
                    id: u.id,
                    firstName: u.firstName,
                    lastName: u.lastName,
                    email: u.email,
                    role: u.role,
                }));
                setUsers(usersData);
            } catch (err) {
                console.error('Error fetching users:', err);
                setError('Failed to fetch users');
            } finally {
                setLoading(false);
            }
        };

        getUsers();
    }, []);

    const table = useMaterialReactTable({
        columns,
        data: users,
    });

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div className={styles['users-list-container']}>
            <MaterialReactTable table={table} />
        </div>
    );
};

export default UsersList;